using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PatientEntity;
using PatientManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.Controllers
{
    public class HomeController : Controller
    {
        private Patient _pobj = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Patient pobj, IConfiguration config)
        {
            _logger = logger;
            var va = config["ConnectionStrings:DefaultConnection"];
            _pobj = pobj;
        }
        int i = 0;
        public IActionResult Index()
        {
            var temp = HttpContext.Session.GetInt32("value of i");
            i++;
            HttpContext.Session.SetInt32("value of i",i);
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
