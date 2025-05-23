using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication452_simple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Accessed Index page.");
            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            _logger.LogInformation("Accessed About page.");
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            _logger.LogInformation("Accessed Contact page.");
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}