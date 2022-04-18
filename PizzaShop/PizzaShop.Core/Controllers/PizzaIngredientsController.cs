using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Core.ViewModels.PizzaIngredients;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class PizzaIngredientsController : Controller
    {
        private readonly PizzaShopDbContext context;
        public PizzaIngredientsController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexViewModel model)
        {
            model.Pizzas = this.context.Pizzas.ToList();
            model.Ingredients = this.context.Ingredients.ToList();



            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 6
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.PizzaIngredients.Count() / (double)model.Pager.ItemsPerPage);

            model.PizzaIngredients = context.PizzaIngredients
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(6)
                                     .ToList();

            return this.View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateViewModel()
            {
                Pizzas = this.context.Pizzas.ToList(),
                Ingredients = this.context.Ingredients.ToList(),
                Pizza = new Pizza(),
                Ingredient = new Ingredient()
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new PizzaIngredient()
            {
                PizzaId = model.PizzaId,
                IngredientId = model.IngredientId,
                Pizza = model.Pizza,
                Ingredient = model.Ingredient
            };

            this.context.PizzaIngredients.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "PizzaIngredients");
        }

        public IActionResult Delete(int id)
        {

            var item = new PizzaIngredient();
            item.Id = id;

            this.context.PizzaIngredients.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "PizzaIngredients");
        }
    }
}
