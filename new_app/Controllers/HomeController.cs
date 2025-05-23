using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/About
        [HttpGet]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // GET: /Home/Contact
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}