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
    public class CVJobApplicationUsers1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public CVJobApplicationUsers1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CVJobApplicationUsers1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CVJobApplicationUser.Include(c => c.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CVJobApplicationUsers1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVJobApplicationUser = await _context.CVJobApplicationUser
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (cVJobApplicationUser == null)
            {
                return NotFound();
            }

            return View(cVJobApplicationUser);
        }

        // GET: CVJobApplicationUsers1/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: CVJobApplicationUsers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,ApplicationUserId,JobsId")] CVJobApplicationUser cVJobApplicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cVJobApplicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", cVJobApplicationUser.ApplicationUserId);
            return View(cVJobApplicationUser);
        }

        // GET: CVJobApplicationUsers1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVJobApplicationUser = await _context.CVJobApplicationUser.FindAsync(id);
            if (cVJobApplicationUser == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", cVJobApplicationUser.ApplicationUserId);
            return View(cVJobApplicationUser);
        }

        // POST: CVJobApplicationUsers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobId,ApplicationUserId,JobsId")] CVJobApplicationUser cVJobApplicationUser)
        {
            if (id != cVJobApplicationUser.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cVJobApplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVJobApplicationUserExists(cVJobApplicationUser.ApplicationUserId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", cVJobApplicationUser.ApplicationUserId);
            return View(cVJobApplicationUser);
        }

        // GET: CVJobApplicationUsers1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cVJobApplicationUser = await _context.CVJobApplicationUser
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ApplicationUserId == id);
            if (cVJobApplicationUser == null)
            {
                return NotFound();
            }

            return View(cVJobApplicationUser);
        }

        // POST: CVJobApplicationUsers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cVJobApplicationUser = await _context.CVJobApplicationUser.FindAsync(id);
            _context.CVJobApplicationUser.Remove(cVJobApplicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVJobApplicationUserExists(string id)
        {
            return _context.CVJobApplicationUser.Any(e => e.ApplicationUserId == id);
        }
    }
}
