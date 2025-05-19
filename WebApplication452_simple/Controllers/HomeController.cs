using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication452.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult About()
        {
            return View("About");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}