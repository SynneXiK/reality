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
        public IActionResult OfferUpdate(int idOffer)
        {
            this.ViewBag.Offer = MyContext.Offers.Where(x => x.id == idOffer);
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
    }
}
