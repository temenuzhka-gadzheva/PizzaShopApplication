using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.ViewModels.Ingredients;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly PizzaShopDbContext context;
        public IngredientsController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexViewModel model)
        {

            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 4
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Ingredients.Count() / (double)model.Pager.ItemsPerPage);

            model.Ingredients = context.Ingredients
                                   .OrderBy(i => i.Id)
                                   .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                   .Take(4)
                                   .ToList();

            return this.View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Ingredient()
            {
                Name = model.Name
            };
            this.context.Ingredients.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "Ingredients");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Ingredients.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Ingredients");

            var model = new EditViewModel()
            {
                Id = item.Id,
                Name = item.Name
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Ingredient()
            {

                Id = model.Id,
                Name = model.Name
            };

            this.context.Ingredients.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Ingredients");
        }

        public IActionResult Delete(int id)
        {

            var item = new Ingredient();
            item.Id = id;


            this.context.Ingredients.Remove(item);
            this.context.SaveChanges();
            return RedirectToAction("Index", "Ingredients");
        }
    }
}
