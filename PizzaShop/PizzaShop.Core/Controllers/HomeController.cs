using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.Authentication;
using PizzaShop.Core.SessionHelper;
using PizzaShop.Core.ViewModels.Home;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;


namespace PizzaShop.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly PizzaShopDbContext context;
        public HomeController(PizzaShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loggedUser = this.context.Users.
               Where(x => x.Username == model.Username && x.Password == model.Password)
               .FirstOrDefault();

            if (!this.ModelState.IsValid)
                return this.View(model);


            if (loggedUser == null)
                return RedirectToAction("Register", "Home");


            HttpContext.Session.SetObjectAsJson("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (this.ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = model.Password
                };

                if (!this.context.Users.Contains(user))
                {
                    this.context.Users.Add(user);
                    this.context.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
                return RedirectToAction("Login", "Home");

            }

            var registeredUser = this.context.Users.
                Where(x => x.FirstName == model.FirstName
                && x.LastName == model.LastName
                && x.Username == model.Username
                && x.Password == model.Password)
                .FirstOrDefault();

            if (registeredUser != null)
                return this.View(model);


            HttpContext.Session.SetObjectAsJson("loggedUser", registeredUser);
    
            if (!this.ModelState.IsValid)
                return this.View(model);


            return RedirectToAction("Index", "Home");
        }

        [Authentication]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Register", "Home");
        }
    }
}
