﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Intro.Filters
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
