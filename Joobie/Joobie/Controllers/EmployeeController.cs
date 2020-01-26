using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Joobie.Data;
using Joobie.Models.JobModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Joobie.Utility;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Joobie.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;

        private const string _cVFilePath = "/Joobie/Joobie/wwwroot/cVs";

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Applied()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            return View();

        }


        [Authorize(Roles = Strings.EmployeeUser)]
        public async Task<IActionResult> Apply(long Id)
        {
            var job = await _context.Job.Include(j => j.Category)
                .Include(j => j.TypeOfContract)
                .Include(j => j.WorkingHours)
                .Include(j => j.ApplicationUser)
                .Where(j => j.Id == Id)
                .FirstOrDefaultAsync();
            CVJobApplicationUser cVJobApplicationUser = new CVJobApplicationUser
            {
                Job = job,
                JobsId = Id
            };
            return View(cVJobApplicationUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(CVJobApplicationUser cVJobApplicationUser)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userId = claim.Value;
            cVJobApplicationUser.EmployeeUserId = userId;
            var uniqueName = "";
            bool saveImageSuccess = true;
            if (!ModelState.IsValid)
            {
                return View("Apply", cVJobApplicationUser);
            }
            var cVJobApplicationUserInDb = await _context.CVJobApplicationUser.FirstOrDefaultAsync(c => c.EmployeeUserId == userId && c.JobsId == cVJobApplicationUser.JobsId);
            if (cVJobApplicationUserInDb != null)
            {
                uniqueName = cVJobApplicationUserInDb.CvName;
                cVJobApplicationUserInDb.Job = cVJobApplicationUser.Job;
                cVJobApplicationUserInDb.EmployeeUser = cVJobApplicationUser.EmployeeUser;

                if (Request.Form.Files.Any())
                    saveImageSuccess = await SaveCvToDirectory(uniqueName);
                if (saveImageSuccess == false)
                    return View("Error");

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }


            uniqueName = await GetUniqueFileName();
            cVJobApplicationUser.CvName = Path.GetFileNameWithoutExtension(uniqueName)
                + Path.GetExtension(cVJobApplicationUser.Cv.FileName);
            saveImageSuccess = await SaveCvToDirectory(cVJobApplicationUser.CvName);
            if (saveImageSuccess == false)
                return View("Error");
            await _context.CVJobApplicationUser.AddAsync(cVJobApplicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SaveCvToDirectory(string fileName)
        {
            IFormFile file = Request.Form.Files.First();
            string pathSrc = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            pathSrc += _cVFilePath;
            using (var stream = new FileStream(Path.Combine(pathSrc, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }


        private async Task<string> GetUniqueFileName()
        {
            string fileName = "";
            await Task.Run(() =>
            {
                fileName = Path.GetRandomFileName();
                string path = Path.Combine("~/Data/Cvs", fileName);
                while (System.IO.File.Exists(path))
                {
                    fileName = Path.GetRandomFileName();
                    path = Path.Combine("~/Data/Cvs", fileName);
                }
            });

            return fileName;
        }
    }
}
