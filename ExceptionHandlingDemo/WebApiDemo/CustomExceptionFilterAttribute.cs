using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApiDemo
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            // Some logic to handle specific exceptions
            var errorMessage = context.Exception is ArgumentException 
                ? "ArgumentException occurred" 
                : "Some unknown error occurred";

            // Maybe, logging the exception
            _logger.LogError(context.Exception, errorMessage);

            // Returning response
            context.Result = new BadRequestResult();
        }
    }
}
