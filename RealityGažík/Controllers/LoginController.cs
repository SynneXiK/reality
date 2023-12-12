using Microsoft.AspNetCore.Mvc;
using RealityGažík.Attributes;
using RealityGažík.Models;

namespace RealityGažík.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        [LoginSecured]
        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [LoginSecured]
        public IActionResult Index(LoginModel model)
        {
            var user = MyContext.Users.FirstOrDefault(u => u.username == model.username && u.password == model.password);

            if (user != null)
            {
                this.HttpContext.Session.SetInt32("login", user.id);
                this.HttpContext.Session.SetString("isuser", "true");
                return RedirectToAction("Index", "Home");
            }

            var admin = MyContext.Admins.FirstOrDefault(a => a.username == model.username && a.password == model.password);

            if (admin != null)
            {
                this.HttpContext.Session.SetInt32("login", admin.id);
                this.HttpContext.Session.SetString("isadmin", Convert.ToString(admin.isAdmin));
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("login");

            return RedirectToAction("Index", "Home");
        }
    }
}
