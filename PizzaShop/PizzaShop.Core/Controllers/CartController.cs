using Microsoft.AspNetCore.Mvc;
using PizzaShop.Core.SessionHelper;
using PizzaShop.Models.Data;
using PizzaShop.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShop.Core.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly PizzaShopDbContext context;
        public CartController(PizzaShopDbContext context)
        {
            this.context = context;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var cart = Session.
                GetObjectFromJson<List<Item>>
                (HttpContext.Session, "cart");

            ViewBag.cart = cart;
            ViewBag.total = cart;
            if (ViewBag.total == null)
            {
                ViewBag.total = null;
            }
            else
            {
                ViewBag.total = cart.Sum(x => x.Pizza.Price * x.Quantity);
            }
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {

            if (Session.
                 GetObjectFromJson<List<Item>>
                 (HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item { Pizza = this.context.Pizzas.Find(id), Quantity = 1 });
                Session.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = Session.
             GetObjectFromJson<List<Item>>
             (HttpContext.Session, "cart");
                var index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item { Pizza = this.context.Pizzas.Find(id), Quantity = 1 });
                }
                else
                {
                    cart[index].Quantity++;
                }
                Session.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("All", "Pizzas");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {

            var cart = Session.
         GetObjectFromJson<List<Item>>
         (HttpContext.Session, "cart");
            var index = Exists(cart, id);
            cart.RemoveAt(index);
            Session.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        [Route("Checkout")]
        public IActionResult Checkout(int id)
        {
            return View();
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pizza.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
