using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("error")]
        public IActionResult Error()
        {
            return StatusCode(500, "Internal server error");
        }
    }
}