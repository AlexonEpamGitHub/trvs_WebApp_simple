using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Assign a static string to ViewBag.Message.
            // Ensure that the corresponding View properly encodes this content when rendered.
            ViewBag.Message = HttpUtility.HtmlEncode("Your application description page.");

            return View();
        }

        public ActionResult Contact()
        {
            // Assign a static string to ViewBag.Message.
            // Ensure that the corresponding View properly encodes this content when rendered.
            ViewBag.Message = HttpUtility.HtmlEncode("Your contact page.");

            return View();
        }
    }
}
