using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication452_simple.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationDescriptionService _applicationDescriptionService;
        private readonly IContactService _contactService;

        public HomeController(IApplicationDescriptionService applicationDescriptionService, IContactService contactService)
        {
            _applicationDescriptionService = applicationDescriptionService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _applicationDescriptionService.GetDescription();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = _contactService.GetContactMessage();

            return View();
        }
    }

    public interface IApplicationDescriptionService
    {
        string GetDescription();
    }

    public interface IContactService
    {
        string GetContactMessage();
    }
}