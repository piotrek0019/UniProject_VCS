using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.Models;
using UniProject.Models.IMS;
using UniProject.Models.ViewModels;

namespace UniProject.Controllers
{
    public class IMSController : Controller
    {
        private UniDbContext _context;
        public IMSController()
        {
            _context = new UniDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        // GET: IMS
        public ActionResult Index()
        {
            return View();
        }
        
        //Transactions /////////////////////////////////////
        [HttpGet]
        public ActionResult NewTrans(int? id, int? url)
        {
            try
            { 
            if (id == null || url == null)
                return Content("Try again");


            ViewBag.url = url;
            ViewBag.id = id;

            var customers = _context.Customers.ToList();
            var propertiesIMS = _context.PropertyIMSs.ToList();
            var transTypes = _context.TransTypes.ToList();

            var viewModel = new TransTypeCustPropViewModel
            {
                Transaction = new Transaction(),
                Customer = customers,
                PropertyIMS = propertiesIMS,
                TransType = transTypes
            };
            if(url == 1)
                viewModel.Transaction.CustomerId = id.Value;

            if (url == 2)
                viewModel.Transaction.PropertyIMSId = id.Value;
                        
            return View(viewModel);
            }
            catch(Exception e)
            {
                return Content("Something has gone wrong");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTrans(Transaction transaction, int url)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.url = url;

                if(url == 1)
                    ViewBag.id = transaction.CustomerId;

                if (url == 2)
                    ViewBag.id = transaction.PropertyIMSId;

                var customers = _context.Customers.ToList();
                var propertiesIMS = _context.PropertyIMSs.ToList();
                var transTypes = _context.TransTypes.ToList();
                var test = transaction;
                var viewModel = new TransTypeCustPropViewModel
                {
                    Transaction = transaction,
                    Customer = customers,
                    PropertyIMS = propertiesIMS,
                    TransType = transTypes
                };
                return View(viewModel);
            }
            transaction.Date = DateTime.Now;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();


            if (url == 2)
                return RedirectToAction("DetailProperty", new { id = transaction.PropertyIMSId });

            if (url == 1)
                return RedirectToAction("DetailCustomer", new { id = transaction.CustomerId });

            return RedirectToAction("Index", "IMS");

        }
        [HttpGet]
        public ActionResult EditTrans(int id, int url)
        {
            var transaction = _context.Transactions.SingleOrDefault(t => t.Id == id);

            ViewBag.url = url;

            if (transaction == null)
                return HttpNotFound();

            var customers = _context.Customers.ToList();
            var propertiesIMS = _context.PropertyIMSs.ToList();
            var transTypes = _context.TransTypes.ToList();
            var test = transaction;
            var viewModel = new TransTypeCustPropViewModel
            {
                Transaction = transaction,
                Customer = customers,
                PropertyIMS = propertiesIMS,
                TransType = transTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrans(Transaction transaction, int url)
        {
            if(!ModelState.IsValid)
            {
                var transactionForView = _context.Transactions.SingleOrDefault(t => t.Id == transaction.Id);

                ViewBag.url = url;

                if (transaction == null)
                    return HttpNotFound();

                var customers = _context.Customers.ToList();
                var propertiesIMS = _context.PropertyIMSs.ToList();
                var transTypes = _context.TransTypes.ToList();
                var test = transaction;
                var viewModel = new TransTypeCustPropViewModel
                {
                    Transaction = transaction,
                    Customer = customers,
                    PropertyIMS = propertiesIMS,
                    TransType = transTypes
                };
                return View(viewModel);

            }
           


            var transactionInDb = _context.Transactions.Single(t => t.Id == transaction.Id);

            transactionInDb.Price = transaction.Price;
            transactionInDb.CustomerId = transaction.CustomerId;
            transactionInDb.PropertyIMSId = transaction.PropertyIMSId;
            transactionInDb.TransTypeId = transaction.TransTypeId;

            _context.SaveChanges();

            if (url == 2)
                return RedirectToAction("DetailProperty", new { id = transaction.PropertyIMSId });

            if (url == 1)
                return RedirectToAction("DetailCustomer", new { id = transaction.CustomerId });

            return RedirectToAction("Index", "IMS");
        }

        //Properites  ///////////////////////////////////////////////////////
        public ActionResult ListProperty()
        {
            var property = _context.PropertyIMSs.ToList();

            return View(property);
        }
        [HttpGet]
        public ActionResult NewProperty()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProperty(PropertyIMS property)
        {
            if (ModelState.IsValid)
            {
                _context.PropertyIMSs.Add(property);
                _context.SaveChanges();
                return RedirectToAction("ListProperty");
            }

            return View("NewProperty");
        }
        public ActionResult DetailProperty(int? id)
        {
            if (id == null)
                return Content("Try again");

            var propertyIMS = _context.PropertyIMSs.SingleOrDefault(p => p.Id == id);
            var transactions = _context.Transactions.Where(t => t.PropertyIMSId == id).ToList();
            var customers = _context.Customers.ToList();
            var tranType = _context.TransTypes.ToList();

            var ViewModel = new PropTransCustViewModel
            {
                PropertyIMS = propertyIMS,
                Transaction = transactions,
                Customer = customers,
                TransType = tranType
            };

            return View(ViewModel);
        }
        [HttpGet]
        public ActionResult EditProperty(int? id)
        {
            var property = _context.PropertyIMSs.SingleOrDefault(p => p.Id == id);

            if(property == null)
                return Content("Try again");

            return View(property);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProperty(PropertyIMS property)
        {
            if(!ModelState.IsValid)
            {
                var propertyForView = _context.PropertyIMSs.SingleOrDefault(p => p.Id == property.Id);
                return View(propertyForView);
            }

            var propertyInDb = _context.PropertyIMSs.SingleOrDefault(p => p.Id == property.Id);

            propertyInDb.Name = property.Name;
            propertyInDb.Adress = property.Adress;
            propertyInDb.City = property.City;
            propertyInDb.PostCode = property.PostCode;
            propertyInDb.Description = property.Description;

            _context.SaveChanges();

            return RedirectToAction("DetailProperty", new { id = property.Id });
        }

        //Customers   //////////////////////////////////////////////////////
        public ActionResult ListCustomer()
        {
            var customer = _context.Customers.ToList();

            return View(customer);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NewCustomer(Customer customer)
        {

            if (!ModelState.IsValid)
                return View();

            if (customer == null)
                HttpNotFound();

            _context.Customers.Add(customer);

            _context.SaveChanges();

            return RedirectToAction("ListCustomer");
        }
        public ActionResult DetailCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

           if (customer == null)
                return Content("Try again");

            var transactions = _context.Transactions.Where(t => t.CustomerId == id).ToList();
            var propertyIMS = _context.PropertyIMSs.ToList();
            var tranType = _context.TransTypes.ToList();
            var phone = _context.Phones.Where(p => p.CustomerId == id).ToList();
            var email = _context.Emails.Where(p => p.CustomerId == id).ToList();
            var service = _context.Services.Where(s => s.CustomerId == id).ToList();

            if (customer == null)
                HttpNotFound();

            var ViewModel = new CustTransPropViewModel
            {
                Customer = customer,
                Transaction = transactions,
                TransType = tranType,
                PropertyIMS = propertyIMS,
                Phone = phone,
                Email = email,
                Service = service
            };

            return View(ViewModel);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var customerForView = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                return View(customer);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

            customerInDb.Name = customer.Name;
            customerInDb.Adress = customer.Adress;
            customerInDb.City = customer.City;
            customerInDb.PostCode = customer.PostCode;

            _context.SaveChanges();

            return RedirectToAction("DetailCustomer", new {id = customer.Id});
        }

        //Staff   /////////////////////////////////////////////////////////////

        public ActionResult ListStaff()
        {
            var staff = _context.Staffs.ToList();

            return View(staff);
        }
        [HttpGet]
        public ActionResult NewStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewStaff(Staff staff)
        {
            if (staff == null)
                HttpNotFound();

            _context.Staffs.Add(staff);
            _context.SaveChanges();

            return RedirectToAction("ListStaff");
        }
        [HttpGet]
        public ActionResult EditStaff(int? id)
        {
            var staff = _context.Staffs.SingleOrDefault(s => s.Id == id);
            if (staff == null)
                HttpNotFound();

            return View(staff);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStaff(Staff staff)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(s => s.Id == staff.Id);

            staffInDb.Name = staff.Name;
            staffInDb.Adress = staff.Adress;
            staffInDb.City = staff.City;
            staffInDb.PostCode = staff.PostCode;

            _context.SaveChanges();

            return RedirectToAction("DetailStaff", new { id = staff.Id });
        }
        [HttpGet]
        public ActionResult DetailStaff(int id)
        {
            var phones = _context.Phones.Where(p => p.StaffId == id).ToList();
            var emails = _context.Emails.Where(p => p.StaffId == id).ToList();
            var staff = _context.Staffs.SingleOrDefault(s => s.Id == id);

            var viewModel = new StaffPhoneEmailListViewModel
            {
                Phone = phones,
                Email = emails,
                Staff = staff
            };


            return View(viewModel);
        }
       //Phone ///////////////////////////////////////////////////////////////
        public ActionResult ListPhones()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewPhone(int id, int url)
        {

            ViewBag.url = url;

            var viewModel = new CustPhoneEmailViewModel 
            {
                Phone = new Phone()
            };


            if (url == 1)
            {
                viewModel.Phone.CustomerId = id;
                viewModel.Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            }


            if (url == 2)
            {
                viewModel.Phone.StaffId = id;
                viewModel.Staff = _context.Staffs.SingleOrDefault(c => c.Id == id);
            }

                

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPhone(Phone phone, int url)
        {
            if (phone == null)
                HttpNotFound();

            _context.Phones.Add(phone);
            _context.SaveChanges();

            if(url == 1)
                return RedirectToAction("DetailCustomer", new { id = phone.CustomerId });

            if(url == 2)
                return RedirectToAction("DetailStaff", new { id = phone.StaffId });

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditPhone(int id, int url)
        {
            var phone = _context.Phones.SingleOrDefault(p => p.Id == id);
            ViewBag.url = url;

            if (phone == null)
                HttpNotFound();

            return View(phone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPhone(Phone phone, int url)
        {
            var phoneInDb = _context.Phones.SingleOrDefault(p => p.Id == phone.Id);

            phoneInDb.PhoneNumber = phone.PhoneNumber;

            _context.SaveChanges();

            if (url == 1)
                return RedirectToAction("DetailCustomer", new { id = phoneInDb.CustomerId });

            if (url == 2)
                return RedirectToAction("DetailStaff", new { id = phoneInDb.StaffId });

            return RedirectToAction("Index");
        }
        public ActionResult DetailPhone()
        {
            return View();
        }
        // Email //////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult NewEmail(int id, int url)
        {

            ViewBag.url = url;

            var viewModel = new CustPhoneEmailViewModel
            {
                Email = new Email()
            };

            if (url == 1)
            {
                viewModel.Email.CustomerId = id;
                viewModel.Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            }


            if (url == 2)
            {
                viewModel.Email.StaffId = id;
                viewModel.Staff = _context.Staffs.SingleOrDefault(c => c.Id == id);
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewEmail(Email email, int url)
        {
            if (email == null)
                HttpNotFound();

            _context.Emails.Add(email);
            _context.SaveChanges();
            
            if(url == 1)
                return RedirectToAction("DetailCustomer", new { id = email.CustomerId });

            if (url == 2)
                return RedirectToAction("DetailStaff", new { id = email.StaffId });

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEmail(int id, int url)
        {
            ViewBag.url = url;

            var email = _context.Emails.SingleOrDefault(e => e.Id == id);

            if (email == null)
                HttpNotFound();

            return View(email);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmail(Email email, int url)
        {
            var emailInDb = _context.Emails.SingleOrDefault(p => p.Id == email.Id);

            emailInDb.EmailAdress = email.EmailAdress;

            _context.SaveChanges();

            if (url == 1)
                return RedirectToAction("DetailCustomer", new { id = emailInDb.CustomerId });

            if (url == 2)
                return RedirectToAction("DetailStaff", new { id = emailInDb.StaffId });

            return RedirectToAction("Index");
        }

        // Service /////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult NewService (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new CustServiceViewModel 
            {
                Customer = customer,
                Service = new Service()
            };

            viewModel.Service.CustomerId = id;

            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult NewService(Service service)
        {
            _context.Services.Add(service);

            _context.SaveChanges();

            return RedirectToAction("DetailCustomer", new { id = service.CustomerId });
        }
        [HttpGet]
        public ActionResult EditService(int? id)
        {
            if (id == null)
                return Content("EditService Action has to be called with a paremeter id");

            var service = _context.Services.SingleOrDefault(s => s.Id == id);

            if (service == null)
                HttpNotFound();

            return View(service);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditService(Service service)
        {
            var serviceInDb = _context.Services.SingleOrDefault(s => s.Id == service.Id);

            serviceInDb.Name = service.Name;
            serviceInDb.Price = service.Price;

            _context.SaveChanges();

            return RedirectToAction("DetailCustomer", new { id = serviceInDb.CustomerId });
        }
    }
}