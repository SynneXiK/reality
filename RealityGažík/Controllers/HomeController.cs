using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls.Crypto;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using System.Diagnostics;

namespace RealityGažík.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(char? filter = null, int count = 6)
        {
            this.ViewBag.OffersCount = GetCategories();
            var offers = this.MyContext.Offers.ToList();
            if (filter != null)
                offers = this.MyContext.Offers.Where(x => x.category == filter).ToList();


            this.ViewBag.Offers = offers.Take(Math.Max(6,count)).ToList();

            //var pictureRoutes = this.MyContext.Images.Where(x => x.idOffer == offers.Take(Math.Max(6, count)));

            this.ViewBag.filter = filter;
            this.ViewBag.count = count;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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