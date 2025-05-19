using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Return the default view for the Index action
            return View();
        }

        public IActionResult About()
        {
            // Using ViewData to pass a message to the view
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            // Using ViewData to pass a message to the view
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContactForm(string name, string email, string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                ModelState.AddModelError("", "All fields are required.");
                ViewData["Message"] = "Please fill in all fields.";
                return View("Contact");
            }

            // Simulate saving contact form data (would typically interact with a database or service)
            TempData["SuccessMessage"] = "Thank you for your message. We will get back to you soon.";
            return RedirectToAction("Contact");
        }
    }
}