using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using HttpClientDemo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HttpClientDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GitHubApionsumer _gitHubApionsumer;

        public HomeController(ILogger<HomeController> logger, GitHubApionsumer gitHubApionsumer)
        {
            _logger = logger;
            _gitHubApionsumer = gitHubApionsumer;
        }

        public async Task<IActionResult> Index()
        {
            List<GitHubRepo> repoCollection = await _gitHubApionsumer.GetRepos();
            ViewBag.repoCollection = repoCollection;
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
