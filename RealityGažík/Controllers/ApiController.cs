using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using System.Text;
using System.Text.Json;

namespace RealityGažík.Controllers
{
    public class ApiController : Controller
    {
        MyContext context = new MyContext();
        public IActionResult Test()
        {
            return Json(this.context.Messages.ToList());
        }

        public IActionResult Html()
        {
            this.ViewBag.Messages = this.context.Messages.ToList();

            return View();
        }
        public IActionResult Favorite(Favorite fav)
        {
            if(this.context.Favorites.Any(x => fav.idOffer == x.idOffer && fav.idUser == x.idUser) == false)
            {
                this.context.Favorites.Add(fav);
            }
            else // nvm jestli je spravne dělal jsem na rychlo
            {
                this.context.Favorites.Remove(fav);
            }


            this.context.SaveChanges();
            return Json(true);
        }
    }
    
}