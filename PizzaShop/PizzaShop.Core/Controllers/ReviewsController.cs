using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.SessionHelper;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Core.ViewModels.Reviews;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly PizzaShopDbContext context;
        public ReviewsController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexViewModel model)
        {
            model.Pizzas = this.context.Pizzas.ToList();
            model.Owners = this.context.Users.ToList();

            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 3
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Reviews.Count() / (double)model.Pager.ItemsPerPage);

            model.Reviews = context.Reviews
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(3)
                                     .ToList();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var loggedUser = this.HttpContext.Session.GetObjectFromJson<User>("loggedUser");

            var model = new CreateViewModel()
            {
                Owners = this.context.Users.ToList(),
                Pizzas = this.context.Pizzas.ToList(),
                Owner = loggedUser
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            var loggedUser = this.HttpContext.Session.GetObjectFromJson<User>("loggedUser");
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Review()
            {
                Opinion = model.Opinion,
                Date = model.Date,
                Owner = model.Owner,
                PizzaId = model.PizzaId,
                OwnerId = loggedUser.Id
            };
            this.context.Reviews.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "Reviews");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Reviews.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Reviews");
            var loggedUser = this.HttpContext.Session.GetObjectFromJson<User>("loggedUser");

            var model = new EditViewModel()
            {
                Id = id,
                Opinion = item.Opinion,
                Owner = item.Owner,
                PizzaId = item.PizzaId,
                Pizzas = this.context.Pizzas.ToList(),
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);
            var loggedUser = this.HttpContext.Session.GetObjectFromJson<User>("loggedUser");
            var item = new Review()
            {
                Id = model.Id,
                Opinion = model.Opinion,
                Date = model.Date,
                Owner = model.Owner,
                PizzaId = model.PizzaId,
                OwnerId = loggedUser.Id
            };


            this.context.Reviews.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Reviews");
        }

        public IActionResult Delete(int id)
        {

            var item = new Review();
            item.Id = id;

            this.context.Reviews.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Reviews");
        }
    }
}
