using Joobie.Data;
using Joobie.Models.JobModels;
using Joobie.Utility;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index(string searchString, string citySearchString, int[] categories, int[] typesOfContracts, int[] workingHours)
        {
            IEnumerable<Job> jobs = await GetSortedAndFilteredJobListAsync(searchString, citySearchString, new List<int>(categories),
                new List<int>(typesOfContracts), new List<int>(workingHours));

            ViewData["Categories"] = _context.Category;
            ViewData["TypesOfContracts"] = _context.TypeOfContract;
            ViewData["WorkingHours"] = _context.WorkingHours;

            if (User.IsInRole(Strings.AdminUser))
            {
               
                return View(jobs);
            }
         
            return View("ReadOnlyList",jobs);
        }

       

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.ApplicationUser)
                .Where(j => j.ApplicationUser.Name != null)
                .Include(j => j.Category)
                .Include(j => j.TypeOfContract)
                .Include(j => j.WorkingHours)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        public IActionResult Create()
        {
            ViewData["Employees"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name");
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypesOfContracts"] = new SelectList(_context.TypeOfContract, "Id", "Name");
            ViewData["WorkingHours"] = new SelectList(_context.WorkingHours, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Localization,AddedDate,ExpirationDate,Salary,CategoryId,TypeOfContractId,WorkingHoursId,UserId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employees"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name");
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypesOfContracts"] = new SelectList(_context.TypeOfContract, "Id", "Name");
            ViewData["WorkingHours"] = new SelectList(_context.WorkingHours, "Id", "Name");
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["Employees"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name");
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypesOfContracts"] = new SelectList(_context.TypeOfContract, "Id", "Name");
            ViewData["WorkingHours"] = new SelectList(_context.WorkingHours, "Id", "Name");
            return View(job);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,Localization,AddedDate,ExpirationDate,Salary,CategoryId,TypeOfContractId,WorkingHoursId,UserId")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employees"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name");
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypesOfContracts"] = new SelectList(_context.TypeOfContract, "Id", "Name");
            ViewData["WorkingHours"] = new SelectList(_context.WorkingHours, "Id", "Name");
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.ApplicationUser)
                .Include(j => j.Category)
                .Include(j => j.TypeOfContract)
                .Include(j => j.WorkingHours)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var job = await _context.Job.FindAsync(id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(long id)
        {
            return _context.Job.Any(e => e.Id == id);
        }


        private async  Task<IEnumerable<Job>> GetSortedAndFilteredJobListAsync(string jobNameSearchString, string citySearchString,
            List<int> categories, List<int> typesOfContracts, List<int> workingHours)
        {
            var predicate = PredicateBuilder.New<Job>();
            predicate.DefaultExpression = j => true;
            if (!string.IsNullOrEmpty(jobNameSearchString))
            {
                predicate = predicate.And(j => j.Name.Contains(jobNameSearchString));
            }
            if (!string.IsNullOrEmpty(citySearchString))
            {
                predicate = predicate.And(j => j.Localization.Contains(citySearchString));
            }
            if (categories.Count > 0)
            {
                predicate = predicate.And(j => categories.Contains(j.CategoryId));
            }
            if (typesOfContracts.Count > 0)
            {
                predicate = predicate.And(j => typesOfContracts.Contains(j.TypeOfContractId));
            }
            if (workingHours.Count > 0)
            {
                predicate = predicate.And(j => workingHours.Contains(j.WorkingHoursId));
            }
            predicate = predicate.And(j => j.ApplicationUser.Name != null);

            var jobs = await _context.Job.Where(predicate)
                                .Where(j => j.ApplicationUser.Name != null)
                                 .Include(j => j.Category)
                                 .Include(j => j.TypeOfContract)
                                 .Include(j => j.WorkingHours)
                                 .Include(j => j.ApplicationUser)
                                 .ToListAsync();
            return jobs;
        }
    }
}
