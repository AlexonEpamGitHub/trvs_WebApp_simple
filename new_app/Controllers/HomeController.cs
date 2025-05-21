using Microsoft.AspNetCore.Mvc;

namespace NewApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // Action for the home page
        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                ViewData["Message"] = "Welcome to the Home Page!";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "An error occurred while loading the home page.";
                // Log the exception (assume a logging mechanism is in place)
                // Logger.LogError(ex);
                return View("Error");
            }
        }

        // Action for the About page
        [HttpGet("about")]
        public IActionResult About()
        {
            try
            {
                ViewData["Message"] = "Your application description page.";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "An error occurred while loading the about page.";
                // Log the exception (assume a logging mechanism is in place)
                // Logger.LogError(ex);
                return View("Error");
            }
        }

        // Action for the Contact page
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            try
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "An error occurred while loading the contact page.";
                // Log the exception (assume a logging mechanism is in place)
                // Logger.LogError(ex);
                return View("Error");
            }
        }
    }
}