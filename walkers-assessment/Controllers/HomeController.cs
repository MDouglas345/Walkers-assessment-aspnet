using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using walkers_assessment.Models;
using System;
using System.Linq;

namespace walkers_assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static bool monday = DateTime.Today.DayOfWeek == DayOfWeek.Monday;


        public HomeController(ILogger<HomeController> logger)
        {
            monday = DateTime.Today.DayOfWeek == DayOfWeek.Monday;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("InputTemplate", new ListDataModel {ViewPath = "~/Views/Home/Index.cshtml", isMonday=monday, PageOffset=0});
        }

        public IActionResult Step2()
        {
            return  View("InputTemplate", new ListDataModel { ViewPath = "~/Views/Home/Step2.cshtml", isMonday = monday, PageOffset=0 });
        }

       public IActionResult EntrySubmit(ListDataModel d)
        {
            if (!ModelState.IsValid)
            {
                d.Entries = 0; 
            }
            return View("InputTemplate", d);
        }

        bool validPageOffset(ListDataModel d, int o)
        {
            int tempOff = (d.PageOffset + o) * 20;

            if (tempOff >= d.Entries || tempOff < 0) { return false; }

            return true;

        }

        public IActionResult next(ListDataModel d)
        {
            
            if (validPageOffset(d, 1))
            {
                d.PageOffset++;
            }
            return View("InputTemplate", d);
        }

        public IActionResult prev(ListDataModel d)
        {
            if (validPageOffset(d, -1))
            {
                d.PageOffset--;
            }
            return View("InputTemplate", d);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}