using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // Render the main page
    public IActionResult Index()
    {
        return View();
    }

    // Render the About page with details
    public IActionResult About()
    {
        ViewBag.Message = "Your application description page.";
        return View();
    }

    // Render the Contact page
    public IActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";
        return View();
    }
}