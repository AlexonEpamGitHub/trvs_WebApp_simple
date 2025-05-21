using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication452_simple.Models;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInputModel model)
        {
            if (ModelState.IsValid)
            {
                // Process sanitized and validated user input
                ViewBag.Message = "Input processed successfully.";
            }
            else
            {
                ViewBag.Message = "Invalid input. Please try again.";
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = HttpUtility.HtmlEncode("Your application description page.");

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = HttpUtility.HtmlEncode("Your contact page.");

            return View();
        }
    }
}

namespace WebApplication452_simple.Models
{
    public class UserInputModel
    {
        // Example user input properties with validation
        [Required]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Message must be less than 500 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.,!?]+$", ErrorMessage = "Message contains invalid characters.")]
        public string Message { get; set; }
    }
}