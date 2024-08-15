using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using RealityGažík.Models.Database;

namespace RealityGažík.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string inquiryId)
        {
            Console.WriteLine($"{user} wrote {message} on {inquiryId}");

            await Clients.All.SendAsync("ReceiveMessage", user, message, inquiryId);
        }


    }
}
