using System.IO;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Joobie.Data;
using Joobie.Models.JobModels;
using Joobie.Models;
using Joobie.Utility;
using LinqKit;
using System.Security.Claims;
using Joobie.ViewModels;
using Joobie.Infrastructure;
using Microsoft.AspNetCore.Http;


namespace Joobie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SearchStringSession _searchStringSession;

        public HomeController(ApplicationDbContext context, SearchStringSession searchStringSession)
        {
            _context = context;
            _searchStringSession = searchStringSession;
        }

        public async Task<IActionResult> Index()
        {
            SearchSettingViewModel searchSettingViewModel;
            try
            {
                searchSettingViewModel = await GetSearchSettingViewModel();
                if (_searchStringSession.searchSetting == null)
                {
                    _searchStringSession.SetSearch(searchSettingViewModel);
                }
                return View(searchSettingViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Error");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<SearchSettingViewModel> GetSearchSettingViewModel()
        {
            var categories = await _context.Category.ToListAsync();
            var workingHours = await _context.WorkingHours.ToListAsync();
            var typesOfContracts = await _context.TypeOfContract.ToListAsync();

            var searchSettingViewModel = new SearchSettingViewModel
            {
                Categories = new Filter[categories.Count],
                TypesOfContracts = new Filter[typesOfContracts.Count],
                WorkingHour = new Filter[workingHours.Count]
            };

            for (int i = 0; i < categories.Count; i++)
            {
                searchSettingViewModel.Categories[i] =
                    new Filter { Id = categories[i].Id, Name = categories[i].Name, Selected = false };
            }
            for (int i = 0; i < workingHours.Count; i++)
            {
                searchSettingViewModel.WorkingHour[i] =
                    new Filter { Id = workingHours[i].Id, Name = workingHours[i].Name, Selected = false };
            }
            for (int i = 0; i < typesOfContracts.Count; i++)
            {
                searchSettingViewModel.TypesOfContracts[i] =
                    new Filter { Id = typesOfContracts[i].Id, Name = typesOfContracts[i].Name, Selected = false };
            }

            return searchSettingViewModel;
        }


    }
}
