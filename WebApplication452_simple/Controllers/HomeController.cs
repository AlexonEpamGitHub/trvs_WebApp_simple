using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication452_simple.Models;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        public IActionResult About()
        {
            var model = new AboutViewModel
            {
                Title = "About",
                Message = "Use this area to provide additional information."
            };
            return View(model);
        }

        public async Task<IActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";

            return await Task.FromResult(View());
        }
    }
}

namespace WebApplication452_simple.Models
{
    public class AboutViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}