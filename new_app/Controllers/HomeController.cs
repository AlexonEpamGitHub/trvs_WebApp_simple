using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Accessed Home Index page.");
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            _logger.LogInformation("Accessed About page.");
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            _logger.LogInformation("Accessed Contact page.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitContactForm(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Contact form submission failed due to invalid data.");
                return View("Contact", model);
            }

            // Sanitize inputs
            model.Name = SanitizeInput(model.Name);
            model.Email = SanitizeInput(model.Email);
            model.Message = SanitizeInput(model.Message);

            _logger.LogInformation("Contact form submitted successfully.");
            // Handle form submission logic here (e.g., saving to database, sending email)

            return RedirectToAction("ContactConfirmation");
        }

        [HttpGet]
        public IActionResult ContactConfirmation()
        {
            _logger.LogInformation("Accessed Contact Confirmation page.");
            return View();
        }

        private string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Basic sanitization example using Regex to remove potentially harmful characters
            return Regex.Replace(input, @"[<>]", string.Empty);
        }
    }

    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}