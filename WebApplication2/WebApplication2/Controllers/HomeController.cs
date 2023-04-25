using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication2.Middleware;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AuthenticationMiddleware(actionId: "List", pageId:"1")]
        [Route("HOMEINDEX/{username}")]
        public IActionResult Index([FromRoute] string username)
        {
            ViewBag.Title = "Test du lieu truyen dong tu controller - " + username;
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}