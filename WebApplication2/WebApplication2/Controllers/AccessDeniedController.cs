﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
