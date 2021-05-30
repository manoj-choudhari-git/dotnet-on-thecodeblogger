using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetValueController : ControllerBase
    {
        private readonly ILogger<GetValueController> _logger;

        public GetValueController(ILogger<GetValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [CustomExceptionFilter]
        public IActionResult Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException();
            }

            return Ok("Value");
        }
    }
}
