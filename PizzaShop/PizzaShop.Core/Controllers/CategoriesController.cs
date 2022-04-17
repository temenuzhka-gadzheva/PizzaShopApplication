using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.ViewModels.Categories;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly PizzaShopDbContext context;
        public CategoriesController(PizzaShopDbContext context)
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
                                        ? 2
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Categories.Count() / (double)model.Pager.ItemsPerPage);

            model.Categories = context.Categories
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(2)
                                     .ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var item = new Category()
            {
                Name = model.Name,
                Description = model.Description
            };

            this.context.Categories.Add(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Categories.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Categories");

            var model = new EditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Category()
            {

                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            this.context.Categories.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }

        public IActionResult Delete(int id)
        {

            var item = new Category();
            item.Id = id;

            this.context.Categories.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }

    }
}
