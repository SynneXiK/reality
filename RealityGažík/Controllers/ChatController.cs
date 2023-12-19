using Microsoft.AspNetCore.Mvc;
using RealityGažík.Models;
using RealityGažík.Models.Database;

namespace RealityGažík.Controllers
{
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

                return x.idUser == this.id;
            }).ToList();

            this.ViewBag.Inquiries = inquiries;
            List<Message> lastMsg = new List<Message>();
            foreach (Inquiry item in inquiries)
            {
                lastMsg.Add(MyContext.Messages.Where(x => x.idInquiry == item.id).OrderBy(x => x.time).FirstOrDefault()!);
            }
            this.ViewBag.LastMsg = lastMsg;

            return View();
        }
        public IActionResult Chat(int idInquiry)
        {
            Inquiry inq = MyContext.Inquiries.Find(idInquiry)!;

            List<Message> messages = MyContext.Messages
            .Where(x => x.idInquiry == idInquiry)
            .ToList();

            this.ViewBag.Messages = messages;
            this.ViewBag.id = this.id;

            Admin user = MyContext.Admins.Find(inq.idBroker)!;

            this.ViewBag.name = user.name;

            return View();
        }
    }
}
