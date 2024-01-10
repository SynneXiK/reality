using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls.Crypto;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace RealityGažík.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? filter = null, int idCat = 0)
        {
            List<Offer> offers = this.MyContext.Offers.ToList();
            List<Offer> offersForFilter = offers;
            List<Category> categories = this.MyContext.Categories.ToList();

            List<int> categoriesCount = this.GetCategories(offers, categories);
            for (int i = 0; i < categories.Count; i++)
            {
                categories[i].count = categoriesCount[i];
            }


            Filter _filter = new Filter();
            _filter.count = 6;

            this.ViewBag.Categories = categories;

            this.ViewBag.idUser = this.id;

            List<string> regions = new List<string>();

            offers.ForEach(x =>
            {
                if(!regions.Contains(x.location))
                    regions.Add(x.location);
            });
            this.ViewBag.Regions = regions;

            if (filter != null)
            {
                byte[] decodedJson = Convert.FromBase64String(filter);
                string jsonString = Encoding.UTF8.GetString(decodedJson);
                _filter = JsonSerializer.Deserialize<Filter>(jsonString)!;

                offers = offers
                    .Where(x => _filter.lowestPrice <= x.price && x.price <= _filter.highestPrice)
                    .Where(x => _filter.areaMin <= x.area && x.area <= _filter.areaMax)
                    .ToList();

                if (_filter.region != "All")
                {
                    offers = offers
                             .Where(x => x.location == _filter.region)
                             .ToList();
                }
                if (_filter.categoryId != 0)
                {
                    offers = offers
                        .Where(x => x.idCategory == _filter.categoryId)
                        .ToList();
                }
            }
            else if(this.HttpContext.Session.GetString("filter") != null)
            {
                string jsonString = this.HttpContext.Session.GetString("filter")!;
                _filter = JsonSerializer.Deserialize<Filter>(jsonString)!;

                offers = offers
                    .Where(x => _filter.lowestPrice <= x.price && x.price <= _filter.highestPrice)
                    .Where(x => _filter.areaMin <= x.area && x.area <= _filter.areaMax)
                    .ToList();

                if (_filter.region != "All")
                {
                    offers = offers
                             .Where(x => x.location == _filter.region)
                             .ToList();
                }
                if (_filter.categoryId != 0)
                {
                    offers = offers
                        .Where(x => x.idCategory == _filter.categoryId)
                        .ToList();
                }


            }
            if(idCat != 0)
            {
                offers = offers.Where(x => x.idCategory == idCat).ToList();
            }

            this.ViewBag.Offers = offers/*.OrderByDescending(x => x.id)*/.Take(Math.Max(6, _filter.count)).ToList();
            this.ViewBag.HighestPrice = offersForFilter.Max(x => x.price);
            this.ViewBag.HighestArea = offersForFilter.Max(x => x.area);
            

            List<Favorite> favorites = MyContext.Favorites
            .Where(x => x.idUser == this.id)
            .ToList();
            this.ViewBag.favorites = favorites.Take(Math.Max(6, _filter.count)).ToList();

            List<int> offerIds = offers.Select(o => o.id).ToList();

            var mainImagesQuery = this.MyContext.Images
                .Where(x => offerIds.Contains(x.idOffer) && x.main)
                .GroupBy(x => x.idOffer)
                .Select(g => g.FirstOrDefault());

            this.ViewBag.mainImages = mainImagesQuery.ToList();

            this.ViewBag.filter = filter;
            this.ViewBag.FilterGl = _filter;
            this.ViewBag.count = _filter.count;
            this.ViewBag.categoryid = _filter.categoryId;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult RemoveFilter()
        {
            this.HttpContext.Session.Remove("filter");

            return RedirectToAction("Index");
        }
        public List<int> GetCategories(List<Offer> offers, List<Category> categories)
        {
            List<int> categoriesNum = new List<int>();
            foreach (Category item in categories)
            {
                categoriesNum.Add(offers!.Where(x => x.idCategory == item.id).Count());
            }
            return categoriesNum;
        }
    }
}