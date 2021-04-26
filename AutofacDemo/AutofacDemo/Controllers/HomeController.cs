using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using AutofacDemo.Models;
using AutofacDemo.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutofacDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonService singleton;
        private readonly IScopedService scoped;
        private readonly ITransientService transient;

        public HomeController(ILogger<HomeController> logger, ISingletonService singleton, IScopedService scoped, ITransientService transient)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
        }

        public IActionResult Index()
        {
            ViewData["SingletonCreatedOn"] = this.singleton.CreatedOn;
            ViewData["ScopedCreatedOn"] = this.scoped.CreatedOn;
            ViewData["TransientCreatedOn"] = this.transient.CreatedOn;
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
