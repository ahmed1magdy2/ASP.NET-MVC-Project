using Harbor.Data;
using Harbor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harbor.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly mvcContext dbContext;
        public RequestController (mvcContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult Request()
        {
            ViewData["Ports"] = dbContext.Ports.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Request(Request req)
        {
            var ship = new Ships();
            var cargo = new Cargo();
            var transaction = new Transactions();
            var port = new Ports();
            if (req != null)
            {
                ship.Name = req.ShipName;
                ship.Width = req.Width;
                ship.Length = req.Length;
                ship.ArrivalDate = req.ArrivalDate;
                ship.Coming_from = req.Coming_from;
                cargo.Quantity = req.Quantity;
                cargo.Type= req.CargoType;
                cargo.Destination = req.Destination;
                transaction.Type = req.Type;
                transaction.Date = DateTime.Today;
                transaction.Amount = 0;
                port = dbContext.Ports.FirstOrDefault(u => u.Name == req.portName);
                ship.PortId = port.Id;
                //port = dbContext.Ports.FirstOrDefault(u => u.Name == req.portName);

                dbContext.Ships.Add(ship);
                dbContext.SaveChanges();
                dbContext.Cargoes.Add(cargo);
                dbContext.SaveChanges();
                dbContext.Transactions.Add(transaction);

                dbContext.SaveChanges();
                return RedirectToAction("about","Home");
          
            }
            return Redirect("/Home/contact");
        }

    }
}
