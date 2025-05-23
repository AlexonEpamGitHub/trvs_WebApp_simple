using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        // Action method for the homepage
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        // Action method for the about page
        public IActionResult About()
        {
            ViewData["Title"] = "About Us";
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // Action method for the contact page
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact Us";
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}