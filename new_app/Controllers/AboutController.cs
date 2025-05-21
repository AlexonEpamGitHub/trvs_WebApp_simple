using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}