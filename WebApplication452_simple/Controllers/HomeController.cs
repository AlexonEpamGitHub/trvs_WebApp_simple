using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Simulate async operation if necessary
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> About()
        {
            // Simulate async operation if necessary
            ViewBag.Message = "Your application description page.";
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            // Simulate async operation if necessary
            ViewBag.Message = "Your contact page.";
            await Task.CompletedTask;
            return View();
        }
    }
}