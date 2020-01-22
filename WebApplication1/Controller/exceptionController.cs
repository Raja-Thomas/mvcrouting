using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a=System.Web.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MvcRouting.Controllers
{
    public class exceptionController : Controller
    {
        [a.AllowAnonymous]
        [Route("exception")]
        public IActionResult exception()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");
        }
    }
}