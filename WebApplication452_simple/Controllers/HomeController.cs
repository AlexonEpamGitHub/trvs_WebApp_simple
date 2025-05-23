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
            // Placeholder for new logic based on clarified requirements
            _logger.LogInformation("Accessed Index page.");
            return Ok(); // Ensuring compatibility with IActionResult return type
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            _logger.LogInformation("Accessed About page.");
            var message = new { Message = "Your application description page." };
            return Ok(message);
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            _logger.LogInformation("Accessed Contact page.");
            var message = new { Message = "Your contact page." };
            return Ok(message);
        }
    }
}