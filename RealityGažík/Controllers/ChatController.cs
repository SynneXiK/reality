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

            this.ViewBag.Inquiries = inquiries;

            List<Message> lastMsg = new List<Message>();
            foreach (Inquiry item in inquiries)
            {
                lastMsg.Add(MyContext.Messages.Where(x => x.idInquiry == item.id).OrderBy(x => x.time).FirstOrDefault());
            }
            this.ViewBag.LastMsg = lastMsg;

            return View();
        }
        public IActionResult Chat(int idInquiry)
        {
            List<Message> messages = MyContext.Messages
            .Where(x => x.idInquiry == idInquiry)
            .ToList();
            this.ViewBag.Messages = messages;
            this.ViewBag.id = this.id;
            this.ViewBag.isAdmin = this.isAdmin;

            //UpdateModel user = MyContext.Admins.Find(messages.idUser);

            return View();
        }
    }
}
