using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var model = _homeService.GetIndexModel();
            return View(model);
        }

        public IActionResult About()
        {
            var model = _homeService.GetAboutModel();
            ViewBag.Message = model.Message;
            return View(model);
        }

        public IActionResult Contact()
        {
            var model = _homeService.GetContactModel();
            ViewBag.Message = model.Message;
            return View(model);
        }
    }

    public interface IHomeService
    {
        IndexViewModel GetIndexModel();
        AboutViewModel GetAboutModel();
        ContactViewModel GetContactModel();
    }

    public class HomeService : IHomeService
    {
        public IndexViewModel GetIndexModel()
        {
            return new IndexViewModel();
        }

        public AboutViewModel GetAboutModel()
        {
            return new AboutViewModel
            {
                Message = "Your application description page."
            };
        }

        public ContactViewModel GetContactModel()
        {
            return new ContactViewModel
            {
                Message = "Your contact page."
            };
        }
    }

    public class IndexViewModel
    {
        // Add properties as needed for the Index view
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