using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
