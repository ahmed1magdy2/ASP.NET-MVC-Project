using Harbor.Data;
using Harbor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Harbor.Controllers
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
        public IActionResult About()
        {
            return View("about");
        }
        public IActionResult Request()
        {
            return View("Request");
        }
        public IActionResult Services()
        {
            return View("Services");
        }
        public IActionResult contact()
        {
            return View("contact");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult main()
        {
            return View("main");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}