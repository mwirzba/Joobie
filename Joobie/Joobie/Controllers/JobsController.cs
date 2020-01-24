using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Joobie.Data;
using Joobie.Models.JobModels;

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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Job.Include(j => j.ApplicationUser).Where(j=>j.ApplicationUser.Name!=null).Include(j => j.Category).Include(j => j.TypeOfContract).Include(j => j.WorkingHours);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
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

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypeOfContractId"] = new SelectList(_context.TypeOfContract, "Id", "Name");
            ViewData["WorkingHoursId"] = new SelectList(_context.WorkingHours, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name", job.UserId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", job.CategoryId);
            ViewData["TypeOfContractId"] = new SelectList(_context.TypeOfContract, "Id", "Name", job.TypeOfContractId);
            ViewData["WorkingHoursId"] = new SelectList(_context.WorkingHours, "Id", "Name", job.WorkingHoursId);
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name", job.UserId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", job.CategoryId);
            ViewData["TypeOfContractId"] = new SelectList(_context.TypeOfContract, "Id", "Name", job.TypeOfContractId);
            ViewData["WorkingHoursId"] = new SelectList(_context.WorkingHours, "Id", "Name", job.WorkingHoursId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUser.Where(j => j.Name != null), "Id", "Name", job.UserId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", job.CategoryId);
            ViewData["TypeOfContractId"] = new SelectList(_context.TypeOfContract, "Id", "Name", job.TypeOfContractId);
            ViewData["WorkingHoursId"] = new SelectList(_context.WorkingHours, "Id", "Name", job.WorkingHoursId);
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
    }
}
