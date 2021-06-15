using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace WebApiOrderedFilterDemo
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {

        public CustomActionFilterAttribute()
        {
        }

        public string Scope { get; set; } = "Global";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("OnActionExecuting: " + Name);
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("OnActionExecuted: " + Name);
            base.OnActionExecuted(context);
        }
    }
}
