﻿using Microsoft.AspNetCore.Mvc;

namespace TheEvent.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
