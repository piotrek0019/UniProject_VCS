using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.Models;
using UniProject.Models.ViewModels;

namespace UniProject.Controllers
{
   [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        private UniDbContext _context;

        
        public AdminController()
        {
            _context = new UniDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Properties
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Property property, HttpPostedFileBase[] images)
        {

            if (!ModelState.IsValid)
                return View();

            //saving data to property table
            property.Added = DateTime.Now;
            _context.Properties.Add(property);
            _context.SaveChanges();

            //saving phots
            var lastId = property.Id;
            if (images != null)
            {
                string directory = "~/Content/Images/" + lastId;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(directory));
                }
                var files = new Image();
                foreach (var image in images)
                {
                    if (image != null)
                    {
                        //saving photos to virtual directory
                        image.SaveAs(Server.MapPath(directory + "/" + image.FileName));
                        files.FileName = image.FileName;
                        files.PropertyId = lastId;
                        //saving photo name to database
                        _context.Images.Add(files);

                        _context.SaveChanges();
                    }
                }
                
            }


            return RedirectToAction("PropertyList", "Admin");
        }
        public ActionResult PropertyList()
        {
            var properties = _context.Properties.ToList();

            return View(properties);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           var viewModel = new PropertiesImagesViewModel
            {
                Property = _context.Properties.SingleOrDefault(p => p.Id == id),
                Images = _context.Images.Where(i => i.PropertyId == id).ToList()
            };
           
            

            return View("Edit", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Property property, HttpPostedFileBase[] images)
        {
            var viewModel = new PropertiesImagesViewModel
            {
                Property = _context.Properties.SingleOrDefault(p => p.Id == property.Id),
                Images = _context.Images.Where(i => i.PropertyId == property.Id).ToList()
            };

            if (!ModelState.IsValid)
                return View("Edit", viewModel);
            
            var propertyInDb = _context.Properties.Single(p => p.Id == property.Id);

            propertyInDb.Title = property.Title;
            propertyInDb.Content = property.Content;
            propertyInDb.City = property.City;            
            propertyInDb.Price = property.Price;
            propertyInDb.NoOfBeds = property.NoOfBeds;
            propertyInDb.RentOrBuy = property.RentOrBuy;
            _context.SaveChanges();

            if (images != null)
            {
                string directory = "~/Content/Images/" + property.Id;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(directory));
                }
                var files = new Image();
                foreach (var image in images)
                {
                    if (image != null)
                    {
                        image.SaveAs(Server.MapPath(directory + "/" + image.FileName));
                        files.FileName = image.FileName;
                        files.PropertyId = property.Id;

                        _context.Images.Add(files);

                        _context.SaveChanges();
                    }
                }
                
            }
            
            return RedirectToAction("PropertyList", "Admin");
        }

        //Sub pages
        [HttpGet]
        public ActionResult NewSPage()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSPage(SubPage subPage)
        {
            
            _context.SubPages.Add(subPage);
            _context.SaveChanges();


            return RedirectToAction("Index", "Admin");
        }
       
        public ActionResult ListSPage()
        {
            var sPages = _context.SubPages.ToList();

            return View(sPages);
        }
         [HttpGet]
        public ActionResult EditSPage(int id)
        {
            var sPage = _context.SubPages.SingleOrDefault(s => s.Id == id);

            return View(sPage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSPage(SubPage subPage)
        {
            var sPageInDb = _context.SubPages.Single(s => s.Id == subPage.Id);

            sPageInDb.Title = subPage.Title;
            sPageInDb.Content = subPage.Content;

            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
        //News
        [HttpGet]
        public ActionResult NewNews()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewNews(News news)
        {
            news.Added = DateTime.Now;

            _context.News.Add(news);
            _context.SaveChanges();


            return RedirectToAction("Index", "Admin");
        }
        public ActionResult ListNews()
        {
            var news = _context.News.ToList();

            return View(news);
        }
        [HttpGet]
        public ActionResult EditNews(int id)
        {
            var nPage = _context.News.SingleOrDefault(s => s.Id == id);

            return View(nPage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNews(News newsPage)
        {
            var nPageInDb = _context.News.Single(s => s.Id == newsPage.Id);

            nPageInDb.Title = newsPage.Title;
            nPageInDb.Content = newsPage.Content;


            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }
        
        
        
        
        public ActionResult DeleteEditPhoto(int id)
        {
            var directory = "~/Content/Images/";

            var path = directory + id + "/";

            var images = _context.Images.Where(p => p.PropertyId == id).ToList();
            //deleting photos from virtual directory
            foreach(var image in images)
            {
                var path2 = Request.MapPath(path + image.FileName);
                if (System.IO.File.Exists(path2))
                {
                    System.IO.File.Delete(path2);
                }
            }
            //deleting photos from database
           if(images.Any())
            {
                foreach(var image in images)
                {
                    _context.Images.Remove(image);
                }
                _context.SaveChanges();
            }
             
            return RedirectToAction("Edit", new { id = id });
        }
    }
}