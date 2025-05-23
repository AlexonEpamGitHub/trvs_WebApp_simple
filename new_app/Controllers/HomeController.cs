using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        // Action method for the homepage
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            var result = View();
            if (result == null)
            {
                return NotFound("View for 'Index' was not found.");
            }
            return result;
        }

        // Action method for the about page
        public IActionResult About()
        {
            ViewData["Title"] = "About Us";
            ViewData["Message"] = "Your application description page.";
            var result = View();
            if (result == null)
            {
                return NotFound("View for 'About' was not found.");
            }
            return result;
        }

        // Action method for the contact page
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact Us";
            ViewData["Message"] = "Your contact page.";
            var result = View();
            if (result == null)
            {
                return NotFound("View for 'Contact' was not found.");
            }
            return result;
        }
    }
}