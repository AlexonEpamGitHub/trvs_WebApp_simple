using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace new_app.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            // Sanitize user input
            string sanitizedMessage = HttpUtility.HtmlEncode("Your application description page.");

            // Verify and assign sanitized data to ViewBag
            ViewBag.Message = sanitizedMessage;

            // Ensure no sensitive data is exposed in ViewBag or ViewData
            if (ViewBag.Message == null || string.IsNullOrWhiteSpace(ViewBag.Message.ToString()))
            {
                ViewBag.Message = "Default description page message.";
            }

            return View();
        }
    }
}