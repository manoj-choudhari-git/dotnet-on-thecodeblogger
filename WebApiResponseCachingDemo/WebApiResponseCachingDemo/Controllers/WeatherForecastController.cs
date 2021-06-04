using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApiResponseCachingDemo;

namespace WebApiModelValidationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // cache-control: no-store,no-cache
        // pragma: no-cache
        [HttpGet("nostore")]
        [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None)]
        public IEnumerable<WeatherForecast> Get()
        {
            return GetResponse();
        }

        // cache-control: no-cache,max-age=0 
        // pragma: no-cache
        [HttpGet("store")]
        [ResponseCache(NoStore = false, Duration = 0, Location = ResponseCacheLocation.None)]
        public IEnumerable<WeatherForecast> GetTwo()
        {
            return GetResponse();
        }

        // cache-control: public,max-age=60 
        [HttpGet("Any")]
        [ResponseCache(NoStore = false, Location = ResponseCacheLocation.Any, Duration = 60)]
        public IEnumerable<WeatherForecast> GetThree()
        {
            return GetResponse();
        }

        //  cache-control: private,max-age=60 
        [HttpGet("Client")]
        [ResponseCache(NoStore = false, Location = ResponseCacheLocation.Client, Duration = 60)]
        public IEnumerable<WeatherForecast> GetFour()
        {
            return GetResponse();
        }

        // cache-control: public,max-age=30 
        // vary: User-Agent 
        [HttpGet("VaryByHeader")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public IEnumerable<WeatherForecast> GetFive()
        {
            return GetResponse();
        }

        // NOTE: This requres ResposneCachingMiddleware
        // cache-control: public,max-age=30 
        [HttpGet("VaryByQueryKeys")]
        [ResponseCache(VaryByQueryKeys = new string[] { "*" }, Duration = 30)]
        public IEnumerable<WeatherForecast> GetSix()
        {
            return GetResponse();
        }

        private static IEnumerable<WeatherForecast> GetResponse()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
