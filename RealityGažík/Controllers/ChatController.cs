﻿using Microsoft.AspNetCore.Mvc;
using RealityGažík.Attributes;
using RealityGažík.Models;
using RealityGažík.Models.Database;

namespace RealityGažík.Controllers
{
    [UserSecured]
    public class ChatController : ProfilBaseController
    {
        public IActionResult Index()
        {
            List<Inquiry> inquiries = MyContext.Inquiries.ToList();

            inquiries = inquiries.Where(x =>
            {
                if (this.role == Roles.admin)
                {
                    return true;
                }

                return x.idOwner == this.id || x.idSender == this.id;
            }).ToList();

            this.ViewBag.Inquiries = inquiries;
            List<Admin> admins = MyContext.Admins.ToList();
            //.Where(x => inquiries.Any(inquiry => inquiry.idSender == x.id || inquiry.idOwner == x.id))
            this.ViewBag.Admins = admins;
            this.ViewBag.Id = this.id;
            List<Message> lastMsg = new List<Message>();
            foreach (Inquiry item in inquiries)
            {
                lastMsg.Add(MyContext.Messages.Where(x => x.idInquiry == item.id).OrderByDescending(x => x.time).FirstOrDefault()!);
            }
            this.ViewBag.LastMsg = lastMsg;

            return View();
        }
        public IActionResult Chat(int idInquiry)
        {
            Inquiry inq = MyContext.Inquiries.Find(idInquiry)!;
            Offer ofr = MyContext.Offers.Find(inq.idOffer)!;

            List<Message> messages = MyContext.Messages
            .Where(x => x.idInquiry == idInquiry)
            .OrderBy(x => x.time)
            .ToList();
            

            this.ViewBag.Messages = messages;
            this.ViewBag.id = this.id;
            this.ViewBag.InquiryId = inq.id;

            int searchId = (this.id == ofr.idBroker) ? inq.idSender : inq.idOwner;

            Admin user = MyContext.Admins.Find(searchId)!;

            this.ViewBag.user = user;
            this.ViewBag.offername = ofr.name;

            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message msg)
        {
            msg.idUser = this.id;
            msg.time = DateTime.Now;

            if(msg.text != null)
            {
                this.MyContext.Messages.Add(msg);

                this.MyContext.SaveChanges();
            }

            return RedirectToAction("chat", new { idInquiry = msg.idInquiry});
        }
    }
}
