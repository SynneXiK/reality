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

        public IActionResult Index(string? filter = null)
        {
            List<Offer> offers = this.MyContext.Offers.ToList();
            List<Category> categories = this.MyContext.Categories.ToList();

            List<int> categoriesCount = this.GetCategories(offers, categories);
            for (int i = 0; i < categories.Count; i++)
            {
                categories[i].count = categoriesCount[i];
            }

            

            this.ViewBag.Categories = categories;

            this.ViewBag.idUser = this.id;
            Filter _filter = new Filter();
            _filter.count = 6;

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
                _filter.highestPrice = 12966699;
                _filter.lowestPrice = 0;
                //offers = this.MyContext.Offers.Where(x => x.category == _filter.generalType).ToList();
                offers = this.MyContext.Offers
                    .Where(x => _filter.lowestPrice <= x.price && x.price <= _filter.highestPrice)
                    .Where(x => x.idCategory == _filter.categoryId)
                    .ToList();
            }


            this.ViewBag.Offers = offers/*.OrderByDescending(x => x.id)*/.Take(Math.Max(6, _filter.count)).ToList();
            this.ViewBag.HighestPrice = offers.Max(x => x.price);
            this.ViewBag.HighestArea = offers.Max(x => x.area);
            

            List<Favorite> favorites = MyContext.Favorites
            .Where(x => x.idUser == this.id)
            .ToList();
            this.ViewBag.favorites = favorites.Take(Math.Max(6, _filter.count)).ToList();

            //var labelArea = this.MyContext.Labels.Where(x => x.label.Contains("plocha")).FirstOrDefault();
            //List<Value> valuesArea = this.MyContext.Values.Where(x => x.idLabel == labelArea!.id).ToList();
            //this.ViewBag.HighestArea = offers.Where(x => valuesArea.ForEach(v => v.idOffer == x.id));


            //var pictureRoutes = this.MyContext.Images.Where(x => x.idOffer == offers.Take(Math.Max(6, count)));
            List<int> offerIds = offers.Select(o => o.id).ToList();
            //this.ViewBag.mainImages = this.MyContext.Images
            //    .Where(x => offerIds.Contains(x.idOffer) && x.main == true)
            //    .GroupBy(x => x.idOffer)
            //    .ToList();

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

        public IActionResult SendFilter(Filter filter)
        {
            string filterString = JsonSerializer.Serialize(filter);
            byte[] jsonData = Encoding.UTF8.GetBytes(filterString);
            string filterBase64 = Convert.ToBase64String(jsonData);

            return RedirectToAction("Index", new { filter = filterBase64 });
        }
        public IActionResult SimpleFilter(int filter, Filter filterGl)
        {
            filterGl.categoryId = filter;

            string filterString = JsonSerializer.Serialize(filterGl);
            byte[] jsonData = Encoding.UTF8.GetBytes(filterString);
            string filterBase64 = Convert.ToBase64String(jsonData);

            return RedirectToAction("Index", new { filter = filterBase64 });
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