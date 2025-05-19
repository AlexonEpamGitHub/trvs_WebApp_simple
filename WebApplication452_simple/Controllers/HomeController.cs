using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Returning the view using ASP.NET Core MVC conventions
            return View();
        }

        public IActionResult About()
        {
            // Using ViewData to store application description message
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            // Using ViewData to store contact page message
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}