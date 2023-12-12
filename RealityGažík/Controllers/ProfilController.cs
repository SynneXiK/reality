using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using RealityGažík.Models.Database;

namespace RealityGažík.Controllers
{
    public class ProfilController : BaseController
    {
        private readonly ILogger<ProfilController> _logger;
        public ProfilController(ILogger<ProfilController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LoginModel user;

            if(isUser != true)
                user = MyContext.Admins.Find(id)!;
            else
                user = MyContext.Users.Find(id)!;

            this.ViewBag.User = user;

            return View();
        }
        public IActionResult Offers()
        {
            this.ViewBag.Offers = MyContext.Offers.Where(x => x.idBroker == this.id || this.isAdmin == true);
            return View();
        }
        public IActionResult Brokers()
        {
            this.ViewBag.Brokers = MyContext.Admins.Where(x => x.isAdmin != true);
            return View();
        }
        public IActionResult Users()
        {
            this.ViewBag.Users = MyContext.Users.ToList();
            return View();
        }
        public IActionResult Labels()
        {
            this.ViewBag.Labels = MyContext.Labels.ToList();
            return View();
        }
        public IActionResult OfferUpdate(int idOffer)
        {
            this.ViewBag.Offer = MyContext.Offers.FirstOrDefault(x => x.id == idOffer);
            return View();
        }
        [HttpPost]
        public IActionResult Save(LoginModel model)
        {
            var userToUpdate = isUser ? MyContext.Users.Find(id) : MyContext.Admins.Find(id) as UpdateModel;

            if (userToUpdate != null)
            {
                userToUpdate.email = model.email;
                userToUpdate.name = model.name;
                userToUpdate.tel = model.tel;
                userToUpdate.username = model.username;
            }

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SaveOffer(Offer model)
        {
            Offer offer = MyContext.Offers.Find(model.id)!;

            offer.name = model.name;
            offer.price = model.price;
            offer.location = model.location;
            offer.description = model.description;
            offer.category = model.category;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("offerupdate", new { idOffer = model.id} );
        }
        public IActionResult BrokerRemove(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            MyContext.Admins.Remove(broker);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        public IActionResult BrokerPromote(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            broker.isAdmin = true;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        public IActionResult UserRemove(int idUser)
        {
            User user = MyContext.Users.Find(idUser)!;
            MyContext.Users.Remove(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
        public IActionResult UserPromote(int idUser, bool isAdmin = false)
        {
            User user = MyContext.Users.Find(idUser)!;
            Admin admin = new Admin{
                username = user.username,
                password = user.password,
                name = user.name,
                email = user.email,
                tel = user.tel,
                pfp = user.pfp,
                isAdmin = isAdmin
            };
            MyContext.Admins.Add(admin);
            MyContext.Users.Remove(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
    }
}
