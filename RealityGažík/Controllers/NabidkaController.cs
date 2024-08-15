using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using System.Diagnostics;
using RealityGažík.Models.Database;
using System;
using Microsoft.EntityFrameworkCore;

namespace RealityGažík.Controllers
{
    public class NabidkaController : BaseController
    {
        private readonly ILogger<NabidkaController> _logger;

        public NabidkaController(ILogger<NabidkaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            if(id == null)
                return RedirectToAction("Index", "Home");
            
            var offer = this.MyContext.Offers.Find(id);
            this.ViewBag.Offer = offer;

            var values = this.MyContext.Values
                .Where(x => x.idOffer == id)
                .OrderBy(x => x.idLabel)
                .ToList();
            this.ViewBag.Values = values;

            var labelIds = values.Select(y => y.idLabel).ToList();

            var Labels = this.MyContext.Labels
                .Where(x => labelIds.Contains(x.id))
                .OrderBy(x => x.id)
                .ToList();

            this.ViewBag.Labels = Labels;

            this.ViewBag.Seller = this.MyContext.Admins.FirstOrDefault(x => x.id == offer!.idBroker);

            this.ViewBag.Images = this.MyContext.Images.Where(x => x.idOffer == id).ToList();

            this.ViewBag.User = this.MyContext.Admins.Find(this.id);

            return View();
        }
        public IActionResult CreateInquiry(Inquiry inquiry, int id, Admin? user) // FINISH THIS PLEASE ACTUALLY
        {
            var offer = this.MyContext.Offers.Find(id);

            inquiry.id = 0; // ntsm kde se tomu dává jednička a je moc pozdě večer abych se s tim sral ale bude to ez fr
            inquiry.idOwner = user!.id;
            inquiry.idSender = this.id;
            inquiry.idOffer = offer!.id;
            this.MyContext.Inquiries.Add(inquiry);
            this.MyContext.SaveChanges(); // abych získal id

            this.MyContext.Messages.Add(new Message{
                idInquiry = inquiry.id,
                idUser = this.id,
                text = inquiry.text,
                time = DateTime.Now
            });
            this.MyContext.SaveChanges();

            return RedirectToAction("index", new { id = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
