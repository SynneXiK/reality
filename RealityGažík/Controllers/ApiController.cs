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
        public IActionResult Offers(Filter filter)
        {
            var offers = this.context.Offers.ToList();

            Filter _filter = new Filter();

            if (filter != null)
            {
                _filter = filter;
                _filter.count += 6;
                //offers = this.context.Offers.Where(x => x.category == _filter.generalType).ToList();
                offers = this.context.Offers
                    .Where(x => _filter.lowestPrice <= x.price && x.price <= _filter.highestPrice)
                    .Where(x => _filter.categoryId == 0 || x.idCategory == _filter.categoryId)
                    .ToList();
            }
            HttpContext.Session.SetString("filter", JsonSerializer.Serialize(_filter)); //tojsonstring vlastni metoda

            return Json(offers);
            //return Json(this.context.Messages.ToList());
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
                Favorite favRem = this.context.Favorites.Where(x => x.idOffer == fav.idOffer && x.idUser == fav.idUser).FirstOrDefault()!;
                this.context.Favorites.Remove(favRem);
            }

            this.context.SaveChanges();
            this.TempData["Message"] = "Changes saved";
            return Json(true);
        }
    }
    
}