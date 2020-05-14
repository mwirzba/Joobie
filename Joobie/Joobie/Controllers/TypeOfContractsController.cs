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
    public class TypeOfContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeOfContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfContract.ToListAsync());
        }

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

        public IActionResult Create()
        {
            return View();
        }


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
