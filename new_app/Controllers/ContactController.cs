using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace new_app.Controllers
{
    public class ContactController : Controller
    {
        // This method handles HTTP GET requests for the Contact page.
        [HttpGet]
        public IActionResult Index()
        {
            // Set a message for the Contact page.
            ViewData["Message"] = "Your contact page.";

            // Return the Contact view.
            return View();
        }

        // This method handles HTTP POST requests for the Contact form submission.
        [HttpPost]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks.
        public IActionResult Submit(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulate anti-spam check using honeypot.
                if (!string.IsNullOrEmpty(model.HiddenField))
                {
                    // Honeypot field should be empty to verify the request is not automated spam.
                    ModelState.AddModelError(string.Empty, "Spam detected.");
                    return View("Index");
                }

                // Perform additional processing, e.g., save to database, send email, etc.
                ViewData["Message"] = "Thank you for contacting us!";
                return View("Success");
            }

            // If validation fails, return to Contact page with validation errors.
            return View("Index");
        }
    }

    // ViewModel with validation attributes for input sanitization and format enforcement.
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; }

        // Honeypot field for anti-spam mechanism.
        [BindNever] // Exclude from model binding to prevent automated submission.
        public string HiddenField { get; set; }
    }
}