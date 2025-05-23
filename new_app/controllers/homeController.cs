using Microsoft.AspNetCore.Mvc;

namespace NewApp.Controllers
{
    public class HomeController : Controller
    {
        // Action for the application home page
        public IActionResult Index()
        {
            return View();
        }

        // Action for the About page
        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // Action for the Contact page
        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}