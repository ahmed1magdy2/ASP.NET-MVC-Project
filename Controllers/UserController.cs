using Harbor.Data;
using Harbor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harbor.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly mvcContext dbContext;
        public UserController(mvcContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        public IActionResult login()
        {
            return View("login");
        }
        [HttpGet]
        public IActionResult signup()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult signup(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Redirect("login");
        }
        [HttpPost]
        public IActionResult login(Userlog model)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == model.UserName);
            if (user != null && model.Password == user.Password)
            {
                return RedirectToAction("Services", "Home");
            }
            return View(model);
        }
    }
}
