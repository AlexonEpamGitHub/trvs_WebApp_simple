using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace new_app.Controllers
{
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
            _logger.LogInformation("Accessed Home Index page.");
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            _logger.LogInformation("Accessed About page.");
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            _logger.LogInformation("Accessed Contact page.");
            return View();
        }
    }
}