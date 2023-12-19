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
            //var user = MyContext.Users.Where(u => u.username == model.username).FirstOrDefault();

            //if(user != null && BCrypt.Net.BCrypt.Verify(model.password, user.password))
            //{
            //    this.HttpContext.Session.SetInt32("login", user.id);
            //    this.HttpContext.Session.SetString("isuser", "true");
            //    return RedirectToAction("Index", "Home");
            //}

            //if (user != null)
            //{
            //    this.HttpContext.Session.SetInt32("login", user.id);
            //    this.HttpContext.Session.SetString("isuser", "true");
            //    return RedirectToAction("Index", "Home");
            //}

            Admin admin = MyContext.Admins.Where(a => a.username == model.username).FirstOrDefault();

            if (admin != null && BCrypt.Net.BCrypt.Verify(model.password, admin.password))
            {
                this.HttpContext.Session.SetInt32("login", admin.id);
                this.HttpContext.Session.SetString("role", Convert.ToString(admin.role)!);
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
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            MyContext.Admins.Add(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Account created";
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("login");

            return RedirectToAction("Index", "Home");
        }
    }
}
