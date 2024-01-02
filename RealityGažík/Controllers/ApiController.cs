using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using System.Text;
using System.Text.Json;

namespace RealityGažík.Controllers
{
    public class ApiController : BaseController
    {
        MyContext context = new MyContext();
        public IActionResult Test()
        {
            return Json(this.context.Messages.ToList());
        }
        public IActionResult Offers(Filter filter)
        {
            var offers = this.context.Offers.ToList();

            List<string> regions = new List<string>();

            offers.ForEach(x =>
            {
                if (!regions.Contains(x.location))
                    regions.Add(x.location);
            });
            this.ViewBag.Regions = regions;

            Filter _filter = new Filter();

                _filter = filter;
               // _filter.count += 6;

            offers = offers
                .Where(x => _filter.lowestPrice <= x.price && x.price <= _filter.highestPrice)
                .Where(x => _filter.areaMin <= x.area && x.area <= _filter.areaMax)
                .ToList();
            if(_filter.region != "All")
            {
                offers = offers
                         .Where(x => x.location == _filter.region)
                         .ToList();
            }
            if(_filter.categoryId != 0)
            {
                offers = offers
                    .Where(x => x.idCategory == _filter.categoryId)
                    .ToList();
            }
            this.ViewBag.idUser = this.id;

            if(offers.Count  > 0)
            {
                this.ViewBag.Offers = offers.Take(Math.Max(6, _filter.count)).ToList();
                this.ViewBag.HighestPrice = offers.Max(x => x.price);
                this.ViewBag.HighestArea = offers.Max(x => x.area);

                List<int> offerIds = offers.Select(o => o.id).ToList();

                var mainImagesQuery = this.MyContext.Images
                    .Where(x => offerIds.Contains(x.idOffer) && x.main)
                    .GroupBy(x => x.idOffer)
                    .Select(g => g.FirstOrDefault());

                this.ViewBag.mainImages = mainImagesQuery.ToList();
            }



            List<Favorite> favorites = MyContext.Favorites
            .Where(x => x.idUser == this.id)
            .ToList();
            this.ViewBag.favorites = favorites.Take(Math.Max(6, _filter.count)).ToList();

            this.ViewBag.filter = filter;
            this.ViewBag.FilterGl = _filter;
            this.ViewBag.count = _filter.count;
            this.ViewBag.categoryid = _filter.categoryId;



            HttpContext.Session.SetString("filter", JsonSerializer.Serialize(_filter)); //tojsonstring vlastni metoda

            return PartialView("_Offers");
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