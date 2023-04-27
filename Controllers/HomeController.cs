﻿using asp.net_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp.net_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("main");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult main()
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