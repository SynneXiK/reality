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

            this.ViewBag.OffersCount = GetCategories();
            var offers = this.MyContext.Offers.ToList();
            Filter _filter = new Filter();
            _filter.count = 6;
            if (filter != null)
            {
                byte[] decodedJson = Convert.FromBase64String(filter);
                string jsonString = Encoding.UTF8.GetString(decodedJson);
                _filter = JsonSerializer.Deserialize<Filter>(jsonString)!;

                offers = this.MyContext.Offers.Where(x => x.category == _filter.generalType).ToList();
            }


            //this.ViewBag.Offers = offers.Take(Math.Max(6,_filter.count)).ToList();
            //this.ViewBag.HighestPrice = offers.Max(x => x.price);
            //var labelArea = this.MyContext.Labels.Where(x => x.label.Contains("plocha")).FirstOrDefault();
            //List<Value> valuesArea = this.MyContext.Values.Where(x => x.idLabel == labelArea!.id).ToList();
            //this.ViewBag.HighestArea = offers.Where(x => valuesArea.ForEach(v => v.idOffer == x.id));


            //var pictureRoutes = this.MyContext.Images.Where(x => x.idOffer == offers.Take(Math.Max(6, count)));

            this.ViewBag.filter = filter;
            this.ViewBag.FilterGl = _filter;
            this.ViewBag.count = _filter.count;

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
        public IActionResult SimpleFilter(char filter, Filter filterGl)
        {
            filterGl.generalType = filter;

            string filterString = JsonSerializer.Serialize(filterGl);
            byte[] jsonData = Encoding.UTF8.GetBytes(filterString);
            string filterBase64 = Convert.ToBase64String(jsonData);

            return RedirectToAction("Index", new { filter = filterBase64 });
        }
        public List<int> GetCategories()
        {
            var offers = this.MyContext?.Offers.ToList();
            List<int> categoriesNum = new List<int>
            {
                offers.Where(x => x.category == 'b').Count(),
                offers.Where(x => x.category == 'l').Count(),
                offers.Where(x => x.category == 'd').Count(),
                offers.Where(x => x.category == 'c').Count()
            };
            return categoriesNum;
        }
    }
}