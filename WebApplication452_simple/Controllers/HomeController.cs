using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication452.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Index page");
        }

        public IActionResult About()
        {
            return Ok("Your application description page.");
        }

        public IActionResult Contact()
        {
            return Ok("Your contact page.");
        }
    }
}
