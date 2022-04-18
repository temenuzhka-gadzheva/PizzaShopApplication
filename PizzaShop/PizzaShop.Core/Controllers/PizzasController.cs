using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Core.ViewModels.Pizzas;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaShopDbContext context;
        public PizzasController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexViewModel model)
        {
            model.Categories = this.context.Categories.ToList();

            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 3
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Pizzas.Count() / (double)model.Pager.ItemsPerPage);

            model.Pizzas = context.Pizzas
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(3)
                                     .ToList();

            return this.View(model);
        }
        public IActionResult All(IndexViewModel model)
        {
            model.Categories = this.context.Categories.ToList();


            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 2
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Pizzas.Count() / (double)model.Pager.ItemsPerPage);

            model.Pizzas = context.Pizzas
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(2)
                                     .ToList();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateViewModel()
            {
                Categories = this.context.Categories.ToList()
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Pizza()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                Category = model.Category
            };

            this.context.Pizzas.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "Pizzas");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Pizzas.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Pizzas");

            var model = new EditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                ImageUrl = item.ImageUrl,
                CategoryId = item.CategoryId,
                Category = item.Category,
                Categories = this.context.Categories.ToList()
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Pizza()
            {

                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                Category = model.Category
            };

            this.context.Pizzas.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Pizzas");
        }

        public IActionResult Delete(int id)
        {

            var item = new Pizza();
            item.Id = id;

            this.context.Pizzas.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Pizzas");
        }
    }
}
