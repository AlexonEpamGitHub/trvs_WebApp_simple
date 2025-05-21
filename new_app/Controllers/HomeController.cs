using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        // Action for the home page
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        // Action for the About page
        public IActionResult About()
        {
            ViewData["Title"] = "About Us";
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // Action for the Contact page
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}