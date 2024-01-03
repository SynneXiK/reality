using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using RealityGažík.Attributes;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using Org.BouncyCastle.Asn1.X509;

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
            Admin? admin = MyContext.Admins.Where(a => a.username == model.username).FirstOrDefault();

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
        public IActionResult UploadRegister(Admin user, IFormFile imageFile)
        {
            if (MyContext.Admins.Any(a => a.username == user.username))
            {
                this.TempData["Message"] = "Username already in use";
                return RedirectToAction("register", "login");
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            user.role = Roles.user;

            if (imageFile != null && imageFile.Length > 0)
            {
                string fileExtension = Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", user.username + fileExtension);
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", user.username);
                user.pfp = fileExtension.Substring(1, fileExtension.Count() - 1);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }

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
