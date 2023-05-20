using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harbor.Data;
using Harbor.Models;

namespace Harbor.Controllers
{
    public class UserController : Controller
    {
        private readonly mvcContext _context;

        public UserController(mvcContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'mvcContext.Users'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpGet]
        public IActionResult login()
        {
            return View("login");
        }
        // GET: User/Create
        [HttpGet]
        public IActionResult signup()
        {
            return View(new User());
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> signup([Bind("Id,UserName,NationalId,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName)) != null)
                {
                    Response.WriteAsync("<script>alert('username is already taken');window.location = 'Register';</script>");
                }
                user.Id = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();
                Response.WriteAsync("<script>alert('Hello');window.location = 'Login';</script>");
                return RedirectToAction("login", "User");
            }
            else
            {
                Response.WriteAsync("<script>alert('Something Wrong');window.location = 'signup';</script>");
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult login(Userlog model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);
            if (user != null && model.Password == user.Password)
            {
                HttpContext.Session.SetString("ID", user.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.WriteAsync("<script>alert('Username or Password was Wrong');window.location = 'login';</script>");
            }
            return View("login");
        }
        public IActionResult UserHistory()
        {
            Guid UserID = Guid.Parse(HttpContext.Session.GetString("ID"));
            List<Transaction> Transactions = _context.Transactions.Where(i => i.UserId== UserID).ToList();
            List<Product> userProds = new List<Product>();
            foreach (Transaction e in Transactions)
            {
                Product p = _context.Products.FirstOrDefault(i => i.Id == e.ProductId);
                userProds.Add(p);
            }
            return View(userProds);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("cart");
            return RedirectToAction("login", "User");
        }

        private bool UserExists(Guid id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
