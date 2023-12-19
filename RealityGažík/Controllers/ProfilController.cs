using Microsoft.AspNetCore.Mvc;
using RealityGažík.Attributes;
using RealityGažík.Models;
using RealityGažík.Models.Database;

namespace RealityGažík.Controllers
{
    public class ProfilController : ProfilBaseController
    {
        private readonly ILogger<ProfilController> _logger;
        public ProfilController(ILogger<ProfilController> logger)
        {
            _logger = logger;
        }
        [UserSecured]
        public IActionResult Index()
        {
            Admin admin = MyContext.Admins.Find(id)!;

            this.ViewBag.User = admin;

            return View();
        }
        [BrokerSecured]
        public IActionResult Offers()
        {
            this.ViewBag.Offers = MyContext.Offers.Where(x => x.idBroker == this.id || this.role == Roles.admin.ToString());
            return View();
        }
        [AdminSecured]
        public IActionResult Brokers()
        {
            this.ViewBag.Brokers = MyContext.Admins.Where(x => x.role != Roles.user);
            return View();
        }
        [AdminSecured]
        public IActionResult Users()
        {
            this.ViewBag.Users = MyContext.Admins.Where(x => x.role == Roles.user);
            return View();
        }
        [AdminSecured]
        public IActionResult Labels(int count = 0)
        {
            List<Label> labels = MyContext.Labels.ToList();
            if(count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    labels.Add(new Label { id = 0, label = "" });
                }
            }
            this.ViewBag.Labels = labels;
            this.ViewBag.count = count;

            return View(labels);
        }
        [BrokerSecured]
        public IActionResult OfferUpdate(int idOffer)
        {
            this.ViewBag.Offer = MyContext.Offers.FirstOrDefault(x => x.id == idOffer);
            return View();
        }
        [HttpPost]
        [BrokerSecured]
        public IActionResult Save(Admin model)
        {
            Admin userToUpdate = MyContext.Admins.Find(id)!;

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
        [BrokerSecured]
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
        [AdminSecured]
        public IActionResult BrokerRemove(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            MyContext.Admins.Remove(broker);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        public IActionResult BrokerDemote(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            broker.role = Roles.user;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        
        [AdminSecured]
        public IActionResult BrokerPromote(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            broker.role = Roles.admin;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        [AdminSecured]
        public IActionResult UserRemove(int idUser)
        {
            Admin user = MyContext.Admins.Find(idUser)!;
            MyContext.Admins.Remove(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
        [AdminSecured]
        public IActionResult UserPromote(int idUser, bool isAdmin = false)
        {
            Admin user = MyContext.Admins.Find(idUser)!;
            user.role = Roles.broker;

            MyContext.Admins.Add(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
        [HttpPost]
        [AdminSecured]
        public IActionResult LabelsSave(List<Label> models)
        {
            foreach (var label in models)
            {
                Label existingLabel = MyContext.Labels.Find(label.id)!;

                if (existingLabel != null)
                    existingLabel.label = label.label;

                else
                    MyContext.Labels.Add(label);
                
            }

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("labels");
        }
    }
}
