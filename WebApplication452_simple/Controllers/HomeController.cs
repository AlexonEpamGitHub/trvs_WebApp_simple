using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index action invoked.");
            await Task.CompletedTask; // Simulate asynchronous work if needed
            return View();
        }

        public async Task<IActionResult> About()
        {
            _logger.LogInformation("About action invoked.");
            ViewData["Message"] = "Your application description page.";
            await Task.CompletedTask; // Simulate asynchronous work if needed
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            _logger.LogInformation("Contact action invoked.");
            ViewData["Message"] = "Your contact page.";
            await Task.CompletedTask; // Simulate asynchronous work if needed
            return View();
        }
    }
}