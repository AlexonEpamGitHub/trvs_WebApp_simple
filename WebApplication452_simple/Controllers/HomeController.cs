using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutViewModel
            {
                Message = "Your application description page."
            };

            return View(model);
        }

        public IActionResult Contact()
        {
            var model = new ContactViewModel
            {
                Message = "Your contact page."
            };

            return View(model);
        }
    }

    public class AboutViewModel
    {
        public string Message { get; set; }
    }

    public class ContactViewModel
    {
        public string Message { get; set; }
    }
}