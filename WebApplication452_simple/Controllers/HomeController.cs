using System;
using System.Web.Mvc;
using WebApplication452_simple.Services;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var message = _messageService.GetApplicationDescription();
            ViewData["Message"] = message;

            return View();
        }

        public ActionResult Contact()
        {
            var message = _messageService.GetContactPageDescription();
            ViewData["Message"] = message;

            return View();
        }
    }
}

namespace WebApplication452_simple.Services
{
    public interface IMessageService
    {
        string GetApplicationDescription();
        string GetContactPageDescription();
    }

    public class MessageService : IMessageService
    {
        public string GetApplicationDescription()
        {
            return "Your application description page.";
        }

        public string GetContactPageDescription()
        {
            return "Your contact page.";
        }
    }
}