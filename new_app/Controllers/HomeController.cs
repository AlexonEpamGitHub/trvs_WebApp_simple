using Microsoft.AspNetCore.Mvc;

namespace YourAppNamespace.Controllers
{
    public class HomeController : Controller
    {
        // Action method for the Home page
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the About page
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        // Action method for the Contact page
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}