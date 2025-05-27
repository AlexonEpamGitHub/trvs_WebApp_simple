using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Simulating async operation if needed (e.g., database calls, etc.)
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> About()
        {
            // Simulating async operation if needed
            await Task.CompletedTask;
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            // Simulating async operation if needed
            await Task.CompletedTask;
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}