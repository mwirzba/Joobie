using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joobie.Data;
using Joobie.Models.JobModels;
using Microsoft.AspNetCore.Authorization;
using Joobie.Utility;

namespace Joobie.Controllers
{

    [Authorize(Roles = Strings.AdminUser + "," + Strings.ModeratorUser)]
    public class WorkingHoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkingHoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkingHours.ToListAsync());
        }


        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingHours == null)
            {
                return NotFound();
            }

            return View(workingHours);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingHours);
        }


        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }
            return View(workingHours);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Name")] WorkingHours workingHours)
        {
            if (id != workingHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingHoursExists(workingHours.Id))
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
            return View(workingHours);
        }


        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingHours = await _context.WorkingHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingHours == null)
            {
                return NotFound();
            }

            return View(workingHours);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);
            _context.WorkingHours.Remove(workingHours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingHoursExists(byte id)
        {
            return _context.WorkingHours.Any(e => e.Id == id);
        }
    }
}
