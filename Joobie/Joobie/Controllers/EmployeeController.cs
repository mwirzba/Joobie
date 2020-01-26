using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joobie.Data;
using Joobie.Models.JobModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Joobie.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Joobie.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string _downloadPath = "/Joobie/Joobie/wwwroot/cVs/";
        private static byte _pageSize = 5;

        public EmployeeController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }



        public async Task<IActionResult> Applied()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;

            var applicationDbContext = _context.CVJobApplicationUser.Include(c => c.EmployeeUser)
                .Include(c => c.JobInMiddleTable).ThenInclude(j => j.Category)
                .Include(j => j.JobInMiddleTable).ThenInclude(j => j.TypeOfContract)
                .Include(j => j.JobInMiddleTable).ThenInclude(j => j.WorkingHours)
                .Include(j => j.JobInMiddleTable).ThenInclude(j => j.ApplicationUser)
                .Where(j => j.EmployeeUserId == userId);
            var list = applicationDbContext.ToList();
            return View(list);
        }


        public async Task<IActionResult> JobsOffers(int page = 1)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var jobs = _context.Job.Include(j=>j.ApplicationUser)
                    .Include(j => j.CVJobApplicationUser)
                    .Where(j => j.UserId != user.Id);
            
            int totalJobs = jobs.Count();

            jobs = jobs.OrderBy(c => c.AddedDate)

                  .Skip((page - 1) * _pageSize)
                  .Take(_pageSize);

            var viewModel = new ListViewModel<Job>
            {
                Items = jobs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = (byte)page,
                    ItemsPerPage = _pageSize,
                    TotalItems = (byte)totalJobs
                }
            };

            return View(viewModel);

        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var job = await _context.Job
                             .Include(j => j.CVJobApplicationUser)
                             .Where(j => j.Id == id)
                             .FirstOrDefaultAsync();
            if (job == null)
                return NotFound();

            return View(job);

        }

        public IActionResult Download(string cvPath)
        {
            var path = _downloadPath + cvPath;
            string filePath = path;
            Response.Headers.Add("Content-Disposition", "inline; filename=CV.pdf");
            return File(filePath, "application/pdf");

        }
    }
}
