using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        // Home page action
        public IActionResult Index()
        {
            return View();
        }

        // About page action
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // Contact page action
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}