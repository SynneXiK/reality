using Microsoft.AspNetCore.Mvc;

namespace RealityGažík.Controllers
{
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
