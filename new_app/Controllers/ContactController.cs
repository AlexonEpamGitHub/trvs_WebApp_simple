using Microsoft.AspNetCore.Mvc;

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
    }
}