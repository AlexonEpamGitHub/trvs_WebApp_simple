using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || userInput.Length > 100)
            {
                ModelState.AddModelError("userInput", "Invalid input. Please provide a valid string with a maximum length of 100 characters.");
                ViewBag.Message = "Your application description page.";
                return View();
            }

            userInput = SanitizeInput(userInput);
            ViewBag.Message = $"Your application description page. User Input: {userInput}";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput) || userInput.Length > 100)
            {
                ModelState.AddModelError("userInput", "Invalid input. Please provide a valid string with a maximum length of 100 characters.");
                ViewBag.Message = "Your contact page.";
                return View();
            }

            userInput = SanitizeInput(userInput);
            ViewBag.Message = $"Your contact page. User Input: {userInput}";
            return View();
        }

        private string SanitizeInput(string input)
        {
            return HttpUtility.HtmlEncode(input);
        }
    }
}