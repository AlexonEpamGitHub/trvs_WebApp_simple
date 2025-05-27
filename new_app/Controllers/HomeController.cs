using Microsoft.AspNetCore.Mvc;

namespace new_app.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders the Index page of the application.
        /// </summary>
        /// <returns>View for the Index page.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Renders the About page of the application.
        /// </summary>
        /// <returns>View for the About page.</returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Renders the Contact page of the application.
        /// </summary>
        /// <returns>View for the Contact page.</returns>
        public IActionResult Contact()
        {
            return View();
        }
    }
}