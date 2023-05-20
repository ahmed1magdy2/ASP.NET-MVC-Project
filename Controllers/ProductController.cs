using Harbor.Data;
using Harbor.Models;
using Microsoft.AspNetCore.Mvc;
using MyAccount;
using System.Collections;

namespace Harbor.Controllers
{
    public class ProductController : Controller
    {
        private readonly mvcContext mvcContext;
        private readonly IWebHostEnvironment _environment;
        public ProductController(mvcContext context, IWebHostEnvironment environment)
        {
            this.mvcContext = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product newproduct, IFormFile img_file)
        {
            var Pic = "default.png";
            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img_file.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                Pic = img_file.FileName;
            }
            else
            {
                Pic = "default.png"; // to save the default image path in database.
            }

            var product = new Product
            {
                Id = newproduct.Id,
                Name = newproduct.Name,
                Quantity = newproduct.Quantity,
                Price = newproduct.Price,
                Image = Pic
            };
            try
            {
                mvcContext.Products.Add(product);
                mvcContext.SaveChanges();
                Response.WriteAsync("<script>alert('Success Add New Product');window.location = 'Show';</script>");
            }
            catch (Exception ex)
            {
                Response.WriteAsync("<script>alert('Something Wrong');window.location = 'AddProduct';</script>");
            }
            return RedirectToAction("AddProduct","Product");
        }

        [HttpGet]
        public IActionResult Show()
        {
            List<Product> products = mvcContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Show(Guid id, int num)
        {

            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem item = cart.FirstOrDefault(i => i.ProductID == id);
            if (item != null)
            {

            }
            else
            {
                Product p = mvcContext.Products.FirstOrDefault(i => i.Id == id);
                CartItem newItem = new CartItem
                {
                    ProductID = p.Id,
                    Product_Name = p.Name,
                    Product_Quantity = num,
                    Product_Price = p.Price * num,
                };
                if (newItem.Product_Quantity > p.Quantity)
                {
                    Response.WriteAsync("<script>alert('Not Allowd that Quantity');window.location = 'Show';</script>");
                }
                else if (newItem.Product_Quantity == p.Quantity)
                {
                    cart.Add(newItem);
                    HttpContext.Session.Set("cart", cart);
                }
                else if (num < 0)
                {
                    Response.WriteAsync("<script>alert('Negative Quantity Not Allowed');window.location = 'Show';</script>");
                }
                else
                {
                    cart.Add(newItem);
                    HttpContext.Session.Set("cart", cart);
                }
            }
            return RedirectToAction("Show", "Product");
        }
        public IActionResult Cart()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            return View(cart);
        }
        public IActionResult RemoveFromCart(Guid id)
        {

            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem item = cart.FirstOrDefault(i => i.ProductID == id);
            cart.Remove(item);
            HttpContext.Session.Set("cart", cart);
            return RedirectToAction("Cart");
        }
        public IActionResult Checkout()
        {
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            Guid UsID = Guid.Parse(HttpContext.Session.GetString("ID"));
            foreach (CartItem item in cart)
            {
                var Trans = new Transaction
                {
                    Id = Guid.NewGuid(),
                    UserId = UsID,
                    ProductId = item.ProductID,
                };
                mvcContext.Transactions.Add(Trans);
                mvcContext.SaveChanges();

                Product p = mvcContext.Products.FirstOrDefault(i => i.Id == item.ProductID);
                if (p != null)
                {
                    if (p.Quantity == item.Product_Quantity)
                        mvcContext.Products.Remove(p);
                    else
                        p.Quantity -= item.Product_Quantity;
                }
                mvcContext.SaveChanges();
            }
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Show", "Product");
        }
    }
}
