using Harbor.Data;
using Harbor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harbor.Controllers
{
    public class PortController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly mvcContext dbContext;
        public PortController(mvcContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Ports port )
        {
            dbContext.Ports.Add(port);
            dbContext.SaveChanges();
            return RedirectToAction("main", "Home");
        }
        
    }
}
