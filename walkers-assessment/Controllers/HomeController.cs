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
        static bool monday = DateTime.Today.DayOfWeek == DayOfWeek.Monday;


        public HomeController(ILogger<HomeController> logger)
        {
            monday = DateTime.Today.DayOfWeek == DayOfWeek.Monday;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("InputTemplate", new ListDataModel {ViewPath = "~/Views/Home/Index.cshtml", isMonday=monday});
        }

        public IActionResult Step2()
        {
            return  View("InputTemplate", new ListDataModel { ViewPath = "~/Views/Home/Step2.cshtml", isMonday = monday });
        }

       public IActionResult EntrySubmit(ListDataModel d)
        {
            if (!ModelState.IsValid)
            {
                d.Entries = 0; 
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