using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NBSTimeReporting.Models;

namespace NBSTimeReporting.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        //#Original shait
        //--------------------------------------------------------X
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //--------------------------------------------------------X
        //#Admin
        public IActionResult Admin()
        {
            return View();
        }

        //#Assets
        public IActionResult Assets()
        {
            return View();
        }

        public IActionResult Companies()
        {
            return View();
        }
        public IActionResult People()
        {
            return View();
        }

        public IActionResult Sites()
        {
            return View();
        }

        //#Ticketing
        public IActionResult Ticketing()
        {
            return View();
        }

        //#Reporting
        public IActionResult Reporting()
        {
            return View();
        }

        //#Accounting
        public IActionResult Accounting()
        {
            return View();
        }

        //#Planner
        public IActionResult Planner()
        {
            return View();
        }
        //#DWorkin
        public IActionResult DWorkin()
        {
            return View();
        }

        public IActionResult Regus()
        {
            return View();
        }

        public IActionResult Biogen()
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
