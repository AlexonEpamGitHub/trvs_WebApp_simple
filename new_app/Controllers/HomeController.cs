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
            ViewData["Message"] = "Welcome to the Home Page!";
            return View();
        }

        // Action for the About page
        [HttpGet("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // Action for the Contact page
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}