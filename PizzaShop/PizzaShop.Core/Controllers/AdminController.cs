using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Core.ViewModels.Users;
using PizzaShop.Models.Data;
using System;
using System.Linq;


namespace PizzaShop.Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly PizzaShopDbContext context;
        public AdminController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllUsers(IndexViewModel model)
        {
            model.Orders = this.context.Orders.ToList();

            model.Pager = model.Pager ?? new PagerViewModel();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 3
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Users.Count() / (double)model.Pager.ItemsPerPage);

            model.Users = context.Users
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(3)
                                     .ToList();

            return this.View(model);
        }
    }
}
