using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";
            return await Task.FromResult(View());
        }
    }
}