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

        public HomeController(ApplicationDbContext context, SearchStringSession searchStringSession)
        {
            _context = context;
        }

        // GET: Jobs
        public IActionResult Index()
        {
            return View();
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


    }
}
