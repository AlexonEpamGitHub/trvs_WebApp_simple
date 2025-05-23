using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        public IActionResult About()
        {
            var model = new AboutViewModel
            {
                Message = "Your application description page."
            };
            return View(model);
        }

        public IActionResult Contact()
        {
            var model = new ContactViewModel
            {
                Message = "Your contact page."
            };
            return View(model);
        }
    }

    public class IndexViewModel
    {
        // Add any properties needed for the Index view
    }

    public class AboutViewModel
    {
        public string Message { get; set; }
    }

    public class ContactViewModel
    {
        public string Message { get; set; }
    }
}