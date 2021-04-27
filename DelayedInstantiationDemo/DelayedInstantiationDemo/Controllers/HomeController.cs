using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using AutofacDemo.Services;

using DelayedInstantiationDemo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DelayedInstantiationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Lazy<ICreatedOnDateTimeService> lazyService;

        public HomeController(ILogger<HomeController> logger, Lazy<ICreatedOnDateTimeService> lazyService)
        {
            _logger = logger;
            this.lazyService = lazyService;
        }

        public IActionResult Index([FromQuery]bool create = false)
        {
            ViewData["IsValueCreated"] = this.lazyService.IsValueCreated;

            if (create)
            {
                ViewData["CreatedOn"] = this.lazyService.Value.CreatedOn;
            }

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
