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
    public class TypeOfContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeOfContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeOfContracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfContract.ToListAsync());
        }

        // GET: TypeOfContracts/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfContract = await _context.TypeOfContract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfContract == null)
            {
                return NotFound();
            }

            return View(typeOfContract);
        }

        // GET: TypeOfContracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeOfContract typeOfContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfContract);
        }

        // GET: TypeOfContracts/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfContract = await _context.TypeOfContract.FindAsync(id);
            if (typeOfContract == null)
            {
                return NotFound();
            }
            return View(typeOfContract);
        }

        // POST: TypeOfContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Name")] TypeOfContract typeOfContract)
        {
            if (id != typeOfContract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfContractExists(typeOfContract.Id))
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
            return View(typeOfContract);
        }

        // GET: TypeOfContracts/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfContract = await _context.TypeOfContract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfContract == null)
            {
                return NotFound();
            }

            return View(typeOfContract);
        }

        // POST: TypeOfContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var typeOfContract = await _context.TypeOfContract.FindAsync(id);
            _context.TypeOfContract.Remove(typeOfContract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfContractExists(byte id)
        {
            return _context.TypeOfContract.Any(e => e.Id == id);
        }
    }
}
