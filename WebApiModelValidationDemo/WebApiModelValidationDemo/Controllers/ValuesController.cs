using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiModelValidationDemo.Models;

namespace WebApiModelValidationDemo
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            return employee;
        }
    }
}
