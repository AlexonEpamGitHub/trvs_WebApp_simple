using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}
