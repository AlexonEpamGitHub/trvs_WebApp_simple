using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutModel
            {
                Message = "Your application description page."
            };

            return View(model);
        }

        public IActionResult Contact()
        {
            var model = new ContactModel
            {
                Message = "Your contact page."
            };

            return View(model);
        }
    }

    public class AboutModel
    {
        public string Message { get; set; }
    }

    public class ContactModel
    {
        public string Message { get; set; }
    }
}