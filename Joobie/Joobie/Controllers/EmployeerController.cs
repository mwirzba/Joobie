using Joobie.Data;
using Joobie.Models.JobModels;
using Joobie.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace Joobie.Controllers
{
    public class EmployeerController :  Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string _downloadPath = "~/cVs/";
        private static byte _pageSize = 5;

        public EmployeerController(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> JobsOffers(int page=1)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var jobs = _context.Job
                    .Include(j => j.CVJobApplicationUser)
                    .Where(j => j.UserId == user.Id);

            int totalJobs = jobs.Count();

            jobs = jobs.OrderBy(c => c.AddedDate)
                  
                  .Skip((page - 1) * _pageSize)
                  .Take(_pageSize);

            var viewModel = new ListViewModel<Job>
            {
                Items = jobs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _pageSize,
                    TotalItems = totalJobs
                }
            };

            return View(viewModel);
                
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();
            var job2 =  _context.Job
                            .Include(j => j.CVJobApplicationUser)
                            .ToList();

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var job = _context.Job
                .Include(c  => c.ApplicationUser)
                .Include(c => c.CVJobApplicationUser)
                .ThenInclude(j => j.EmployeeUser)
                .FirstOrDefault(c => c.ApplicationUser.Id == user.Id);


            if (job == null)
                return NotFound();

            return View(job);

        }

        public async Task<IActionResult> Download(string cvPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\cVs\\" + cvPath);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "application/pdf", "CV.pdf");
            }
            else
            {
                ViewBag.Error = "Nie mozna odnaleźć CV skontaktuj się z administatorem.";
                return RedirectToAction(nameof(JobsOffers));
            }
        }

    }
}
