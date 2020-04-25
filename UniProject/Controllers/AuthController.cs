using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniProject.Models;
using System.Security.Claims;

namespace UniProject.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            var model = new User
            {
                ReturnUrl = returnUrl
            };

            

            return View(model);
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using (var _context = new UniDbContext())
            {
                var emailCheck = _context.Users.FirstOrDefault(u => u.Email == model.Email);
               if (emailCheck != null)
                {
                    var getPassword = _context.Users.Where(u => u.Email == model.Email).Select(u => u.Password);
                    var materializedPassword = getPassword.ToList();
                    var password = materializedPassword[0];

                    if (model.Email != null && model.Password == password)
                    {
                        var getName = _context.Users.Where(u => u.Email == model.Email).Select(u => u.Name);
                        var materalizedName = getName.ToList();
                        var name = materalizedName[0];

                        var getEmail = _context.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
                        var materalizedEmail = getEmail.ToList();
                        var email = materalizedEmail[0];



                        var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                    
                },
                        "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;

                        authManager.SignIn(identity);

                        var retUrl = model.ReturnUrl;

                        if (string.IsNullOrEmpty(retUrl) || !Url.IsLocalUrl(retUrl))
                        {
                           return RedirectToAction("Index", "Properties");
                        }
                        return Redirect(retUrl);



                    }
               }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
     

        public ActionResult Logout()
       {
           var ctx = Request.GetOwinContext();
           var authManager = ctx.Authentication;

           authManager.SignOut("ApplicationCookie");

           return RedirectToAction("Login", "Auth");
       }
        

    }
}