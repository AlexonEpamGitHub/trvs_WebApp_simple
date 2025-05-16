using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NewProjectNamespace.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Index page content");
        }

        public IActionResult About()
        {
            var message = "Your application description page.";
            return Ok(new { Message = message });
        }

        public IActionResult Contact()
        {
            var message = "Your contact page.";
            return Ok(new { Message = message });
        }
    }
}