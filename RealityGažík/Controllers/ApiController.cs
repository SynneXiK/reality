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
        List<Offer> offers = new List<Offer>();
        public IActionResult Test()
        {
            return Json(this.context.Messages.ToList());
        }
        public IActionResult Offers(Filter filter)
        {
            GetOffers(filter);

            List<string> regions = new List<string>();

            offers.ForEach(x =>
            {
                if (!regions.Contains(x.location))
                    regions.Add(x.location);
            });
            this.ViewBag.Regions = regions;

            List<Favorite> favorites = MyContext.Favorites
            .Where(x => x.idUser == this.id)
            .ToList();
            this.ViewBag.favorites = favorites.Take(Math.Max(6, Math.Min(offers.Count, filter.count))).ToList();


            if (offers.Count > 0)
            {
                this.ViewBag.Offers = offers.Take(Math.Max(6, Math.Min(offers.Count,filter.count))).ToList();
                this.ViewBag.HighestPrice = offers.Max(x => x.price);
                this.ViewBag.HighestArea = offers.Max(x => x.area);

                List<int> offerIds = offers.Select(o => o.id).ToList();

                var mainImagesQuery = this.MyContext.Images
                    .Where(x => offerIds.Contains(x.idOffer) && x.main)
                    .GroupBy(x => x.idOffer)
                    .Select(g => g.FirstOrDefault());

                this.ViewBag.mainImages = mainImagesQuery.ToList();
            }


            this.ViewBag.idUser = this.id;
            this.ViewBag.filter = filter;
            this.ViewBag.FilterGl = filter;
            this.ViewBag.count = filter.count;
            this.ViewBag.categoryid = filter.categoryId;



            HttpContext.Session.SetString("filter", JsonSerializer.Serialize(filter)); //tojsonstring vlastni metoda

            
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

        
        public IActionResult Value(Value newVal)
        {
            Value checkVal = this.context.Values.FirstOrDefault(x => x.idOffer == newVal.idOffer && x.idLabel == newVal.idLabel)!;
            if(checkVal != null && checkVal.value != newVal.value)
            {
                checkVal.value = newVal.value;
                this.context.Values.Update(checkVal);
            }
            else if (checkVal == null && newVal.value.Trim() != "")
            {
                this.context.Values.Add(newVal);
            }
            this.context.SaveChanges();
            return Json(true);
        }
        private void GetOffers(Filter filter)
        {
            this.offers = this.context.Offers.ToList();

            offers = offers
                .Where(x => filter.lowestPrice <= x.price && x.price <= filter.highestPrice)
                .Where(x => filter.areaMin <= x.area && x.area <= filter.areaMax)
                .ToList();

            if (filter.region != "All")
            {
                offers = offers
                         .Where(x => x.location == filter.region)
                         .ToList();
            }
            if (filter.categoryId != 0)
            {
                offers = offers
                    .Where(x => x.idCategory == filter.categoryId)
                    .ToList();
            }

        }
    }
    
}