using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("Index page");
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return Ok(new { Message = "Your application description page." });
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return Ok(new { Message = "Your contact page." });
        }
    }
}