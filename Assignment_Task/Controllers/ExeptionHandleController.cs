using Assignment_Task.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment_Task.Controllers
{
    public class ExeptionHandleController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ExeptionHandleController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Error(int? statusCode = null)
        {
            var obj=new ErrorViewModel();
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionDetails != null)
            {
                var exception = exceptionDetails.Error;
                obj.stackTrace = exception.StackTrace; // Get the stack trace
                obj.Massage = exceptionDetails.Error.ToString();
            }
            var environmentName = _env.EnvironmentName; // Gets the environment value
            // Do something based on the environment
            if (_env.IsDevelopment())
            {
                obj.Environment = "Development";
                return View("ErrorDev",obj);
            }
            else if (_env.IsProduction())
            {
                // Specific logic for Production environment
                obj.Environment = "Production";
            }
            if (statusCode.HasValue)
            {
                if (statusCode == 404)
                {
                    return View("PageNotFound"); // Return a custom 404 page
                }
            }
            return View(obj);
        }
    }
}
