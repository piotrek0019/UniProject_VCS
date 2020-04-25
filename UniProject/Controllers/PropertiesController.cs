using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UniProject.Models;
using UniProject.Models.ViewModels;
using CaptchaMvc.HtmlHelpers;

namespace UniProject.Controllers
{
     [AllowAnonymous]
    public class PropertiesController : Controller
    {
        private UniDbContext _context;

        public PropertiesController()
        {
            _context = new UniDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        public ActionResult Index()
        {


            return View();
        }

         //Get(Api) /Properties
         [HttpPost]
         public JsonResult Index(string city)
        {
            var properties = _context.Properties.Where(i => i.City.StartsWith(city)).Select(n => n.City);

            return Json(properties, JsonRequestBehavior.AllowGet);
        }
        // GET: Properties
         [HttpPost]
        public ActionResult PropertyList(Property query)
        {
            var property = _context.Properties.Where(r => r.RentOrBuy == query.RentOrBuy).ToList();

            if (query.City != null)
                property = _context.Properties.Where(c => c.City == query.City && c.RentOrBuy == query.RentOrBuy).ToList();


            //var properties = _context.Properties.ToList();
            var viewModel = new PropertiesViewModel
            {
                
                Property = property,
                Images = _context.Images.ToList()
            };

            return View(viewModel);
        }
        public ActionResult Details(int id)
        {

            var viewModel = new PropertiesImagesViewModel
            {
                Property = _context.Properties.SingleOrDefault(p => p.Id == id),
                Images = _context.Images.Where(i => i.PropertyId == id).ToList()
            };
            return View(viewModel);
        }
        public ActionResult SubPage(int id)
        {
            var subPage = _context.SubPages.SingleOrDefault(p => p.Id == id);

            if (subPage == null)
                return HttpNotFound();

            return View(subPage);
        }
        //PartialView Navbar
        public PartialViewResult SubPages()
        {
            var pages = _context.SubPages.ToList();
            pages.Reverse();
            return PartialView("~/Views/Shared/_NavBar.cshtml", pages);
        }

        public ActionResult NewsList()
        {
            var news = _context.News.ToList();

            

            if (news == null)
                return HttpNotFound();

            return View(news);
        }

        public ActionResult News(int id)
        {
            var news = _context.News.SingleOrDefault(n => n.Id == id);

            if (news == null)
                return HttpNotFound();

            return View(news);
        }

        //Email
         
        public ActionResult Email(int id)
        {
            var property = _context.Properties.SingleOrDefault(p => p.Id == id);

            if (property == null)
                return HttpNotFound();

            return View(property);

        }
         [HttpPost]
         public ActionResult SendEmail(string message, string name, string email, string phone, int id)
        {
            if (!this.IsCaptchaValid(""))
            {
                ViewBag.error = "Invalid Captcha";

                var property = _context.Properties.SingleOrDefault(p => p.Id == id);
                return View("Email", property);
            }
            else
            {

                var sender = new MailAddress("piotr@august-web.com");
                var password = "August22!";
                var reciver = new MailAddress("piotr@august-web.com");
                var subject = "Query from: " + name;
                var content = "Name: " + name + "\nEmail: " + email + "\nPhone Number: " + phone + "\n" + message;
                var smtp = new SmtpClient
                {
                    Host = "smtp.webio.pl",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(sender.Address, password)
                };

                using (var mess = new MailMessage(sender, reciver)
                {
                    Subject = subject,
                    Body = content
                })
                {
                    smtp.Send(mess);
                }

                return Content("Massage sent successfully");
            }
        }


    }
}