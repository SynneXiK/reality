using Microsoft.AspNetCore.Mvc;
using RealityGažík.Attributes;
using RealityGažík.Models;
using RealityGažík.Models.Database;
using System;

namespace RealityGažík.Controllers
{
    [UserSecured]
    public class ProfilController : ProfilBaseController
    {
        private readonly ILogger<ProfilController> _logger;
        public ProfilController(ILogger<ProfilController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            Admin admin = MyContext.Admins.Find(id)!;

            this.ViewBag.User = admin;

            return View();
        }
        public IActionResult Favorite()
        {
            List<Favorite> favorites = MyContext.Favorites.Where(x => x.idUser == this.id).ToList();
            this.ViewBag.Favorites = favorites;

            List<int> offerIds = favorites.Select(x => x.idOffer).ToList();
            this.ViewBag.Offers = MyContext.Offers.Where(x => offerIds.Contains(x.id)).ToList();

            this.ViewBag.idUser = this.id;
            return View();
        }
        [BrokerSecured]
        public IActionResult Offers()
        {
            this.ViewBag.Offers = MyContext.Offers.Where(x => x.idBroker == this.id || this.role == Roles.admin.ToString()).ToList();
            return View();
        }
        [AdminSecured]
        public IActionResult Brokers()
        {
            this.ViewBag.Brokers = MyContext.Admins.Where(x => x.role != Roles.user).ToList();
            return View();
        }
        [AdminSecured]
        public IActionResult Users()
        {
            this.ViewBag.Users = MyContext.Admins.Where(x => x.role == Roles.user).ToList();
            return View();
        }

        [AdminSecured]
        public IActionResult Labels(int count = 0)
        {
            List<Label> labels = MyContext.Labels.ToList();
            if(count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    labels.Add(new Label { id = 0, label = "" });
                }
            }
            this.ViewBag.Labels = labels;
            this.ViewBag.count = count;

            return View(labels);
        }
        [BrokerSecured]
        public IActionResult OfferUpdate(int idOffer)
        {
            this.ViewBag.Offer = MyContext.Offers.FirstOrDefault(x => x.id == idOffer);
            this.ViewBag.Categories = MyContext.Categories.ToList();
            List<Image> images = MyContext.Images.Where(x => x.idOffer == idOffer).ToList();
            this.ViewBag.Images = images;
            this.ViewBag.MainId = images.Where(x => x.main).FirstOrDefault()!.id;
            return View();
        }
        [BrokerSecured]
        public IActionResult OfferCreate()
        {
            this.ViewBag.Categories = MyContext.Categories.ToList();
            return View();
        }
        [BrokerSecured]
        public IActionResult NewOffer(Offer offer, List<IFormFile> imageFiles)
        {
            offer.idBroker = this.id;
            this.MyContext.Offers.Add(offer);
            MyContext.SaveChanges();

            foreach (var file in imageFiles)
            {
                if (file != null && file.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "offers", offer.id.ToString(), uniqueFileName + fileExtension);

                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "offers", offer.id.ToString());
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    MyContext.Images.Add(new Image
                    {
                        id = uniqueFileName,
                        idOffer = offer.id,
                        fileExtension = fileExtension.Substring(1, fileExtension.Count() - 1),
                        main = false
                    });
                }
            }
            
            MyContext.SaveChanges();
            MyContext.Images.Where(x => x.idOffer == offer.id).FirstOrDefault()!.main = true;
            MyContext.SaveChanges();
            return RedirectToAction("offers");
        }
        [BrokerSecured]
        public IActionResult OfferRemove(int idOffer)
        {
            Offer offer = MyContext.Offers.Find(idOffer)!;
            if(this.id == offer.idBroker || this.role == Roles.admin)
            {
                this.MyContext.Offers.Remove(offer);
                this.MyContext.SaveChanges();
                this.TempData["Message"] = "Offer Removed";
            }
            else
                this.TempData["Message"] = "Permission Denied";


            return RedirectToAction("offers");
        }
        [HttpPost]
        [BrokerSecured]
        public IActionResult SaveUser(Admin model, IFormFile imageFile)
        {
            Admin userToUpdate = MyContext.Admins.Find(id)!;

            if (imageFile != null && imageFile.Length > 0)
            {
                string fileExtension = Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", model.username + fileExtension);
                model.pfp = fileExtension.Substring(1, fileExtension.Count() - 1);

                if(userToUpdate.name != model.name)
                {
                    string OlddirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", userToUpdate.username + "." + userToUpdate.pfp);
                    System.IO.File.Delete(OlddirectoryPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
            }
            else if(userToUpdate.username != model.username && imageFile == null)
            {
                model.pfp = userToUpdate.pfp;
                string OlddirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", userToUpdate.username + "." + userToUpdate.pfp);
                string newdirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "admins", model.username + "." + model.pfp);
                System.IO.File.Move(OlddirectoryPath, newdirectoryPath);
            }

            if (userToUpdate != null)
            {
                userToUpdate.email = model.email;
                userToUpdate.name = model.name;
                userToUpdate.tel = model.tel;
                userToUpdate.username = model.username;
                userToUpdate.pfp = model.pfp;
            }

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [BrokerSecured]
        public IActionResult SaveOffer(Offer model, List<IFormFile> imageFiles, List<string> imagesToRemove, string mainImageId)
        {
            Offer offer = MyContext.Offers.Find(model.id)!;

            offer.name = model.name;
            offer.price = model.price;
            offer.location = model.location;
            offer.description = model.description;
            offer.idCategory = model.idCategory;

            foreach (var file in imageFiles)
            {
                if (file != null && file.Length > 0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "offers", offer.id.ToString(), uniqueFileName + fileExtension);

                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "podklady", "offers", offer.id.ToString());
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    MyContext.Images.Add(new Image
                    {
                        id = uniqueFileName,
                        idOffer = offer.id,
                        fileExtension = fileExtension.Substring(1, fileExtension.Count() - 1),
                        main = false
                    });
                }
            }

            foreach (var imageId in imagesToRemove)
            {
                var imageToRemove = MyContext.Images.Find(imageId);
                if (imageToRemove != null)
                {
                    MyContext.Images.Remove(imageToRemove);

                    System.IO.File.Delete(Path.Combine("wwwroot", "Images","podklady", "offers", offer.id.ToString(), imageToRemove.id + "." + imageToRemove.fileExtension));
                }
            }


            MyContext.SaveChanges();

            List <Image> imagesToRemake = MyContext.Images.Where(x => x.idOffer == model.id).ToList();
            Image mainImg = MyContext.Images.Find(mainImageId)!;
            imagesToRemake.ForEach(x => x.main = false);
            mainImg.main = true;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("offerupdate", new { idOffer = model.id} );
        }
        [AdminSecured]
        public IActionResult BrokerRemove(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            MyContext.Admins.Remove(broker);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        public IActionResult BrokerDemote(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            broker.role = Roles.user;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        
        [AdminSecured]
        public IActionResult BrokerPromote(int idBroker)
        {
            Admin broker = MyContext.Admins.Find(idBroker)!;
            broker.role = Roles.admin;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("brokers");
        }
        [AdminSecured]
        public IActionResult UserRemove(int idUser)
        {
            Admin user = MyContext.Admins.Find(idUser)!;
            MyContext.Admins.Remove(user);

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
        [AdminSecured]
        public IActionResult UserPromote(int idUser, bool isAdmin = false)
        {
            Admin user = MyContext.Admins.Find(idUser)!;
            user.role = Roles.broker;

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("users");
        }
        [HttpPost]
        [AdminSecured]
        public IActionResult LabelsSave(List<Label> models)
        {
            foreach (var label in models)
            {
                Label existingLabel = MyContext.Labels.Find(label.id)!;

                if (existingLabel != null)
                    existingLabel.label = label.label;

                else
                    MyContext.Labels.Add(label);
                
            }

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("labels");
        }
        [AdminSecured]
        public IActionResult LabelsDelete(List<Label> models)
        {
            foreach (var label in models)
            {
                Label existingLabel = MyContext.Labels.Find(label.id)!;

                MyContext.Labels.Remove(existingLabel);

            }

            MyContext.SaveChanges();
            this.TempData["Message"] = "Changes Saved";
            return RedirectToAction("labels");
        }
    }
}
