using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Index View");
        }

        [HttpGet]
        public IActionResult About()
        {
            var message = "Your application description page.";
            return Ok(new { Message = message });
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var message = "Your contact page.";
            return Ok(new { Message = message });
        }
    }
}