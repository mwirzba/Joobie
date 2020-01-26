using Joobie.Data;
using Joobie.Models.JobModels;
using Joobie.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly string _downloadPath = "/Joobie/Joobie/wwwroot/cVs/";
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

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var job = await  _context.Job
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
