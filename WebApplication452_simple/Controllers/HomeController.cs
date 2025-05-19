using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask; // Simulating asynchronous operation, replace with actual async logic if needed
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            await Task.CompletedTask; // Simulating asynchronous operation, replace with actual async logic if needed
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";
            await Task.CompletedTask; // Simulating asynchronous operation, replace with actual async logic if needed
            return View();
        }
    }
}