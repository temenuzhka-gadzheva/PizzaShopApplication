using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.SessionHelper;
using PizzaShop.Core.ViewModels.Orders;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PizzaShopDbContext context;
        public OrdersController(PizzaShopDbContext context)
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

            model.Pager.PagesCount = (int)Math.Ceiling(context.Orders.Count() / (double)model.Pager.ItemsPerPage);

            model.Orders = context.Orders
                                   .OrderBy(i => i.Id)
                                   .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                   .Take(4)
                                   .ToList();


            return View(model);
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

            var item = new Order()
            {
                CustomerFirstName = model.CustomerFirstName,
                CustomerLastName = model.CustomerLastName,
                CustomerUsersname = model.CustomerUsersname,
                CustomerAddress = model.CustomerAddress,
                CustomerPhone = model.CustomerPhone,
                Date = model.Date
            };

            this.context.Orders.Add(item);
            this.context.SaveChanges();

            return RedirectToAction("Complete", "Orders");
        }

        [HttpGet]
        public IActionResult Complete()
        {

            var cart = new List<Item>();

            Session.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return this.View();
        }
    }
}
