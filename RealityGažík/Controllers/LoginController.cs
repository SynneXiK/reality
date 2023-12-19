using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using RealityGažík.Attributes;
using RealityGažík.Models;
using RealityGažík.Models.Database;

namespace RealityGažík.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        [LoginSecured]
        public IActionResult Index()
        {
            return View(new Admin());
        }

        [HttpPost]
        [LoginSecured]
        public IActionResult Index(Admin model)
        {
            Admin admin = MyContext.Admins.Where(a => a.username == model.username).FirstOrDefault()!;

            if (admin != null && BCrypt.Net.BCrypt.Verify(model.password, admin.password))
            {
                this.HttpContext.Session.SetInt32("login", admin.id);
                this.HttpContext.Session.SetString("role", admin.role);
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
        
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult UploadRegister(Admin user)
        {
            if (MyContext.Admins.Any(a => a.username == user.username))
            {
                this.TempData["Message"] = "Username already in use";
                return RedirectToAction("register", "login");
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            MyContext.Admins.Add(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Account created";
            return RedirectToAction("Index", "login");
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("login");

            return RedirectToAction("Index", "Home");
        }
    }
}
