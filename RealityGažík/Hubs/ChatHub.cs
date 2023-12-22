using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using RealityGažík.Models.Database;

namespace RealityGažík.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message msg)
        {

            await Clients.All.SendAsync("ReceiveMessage", msg);
        }

    }
}
