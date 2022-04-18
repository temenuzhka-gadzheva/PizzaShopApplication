using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;

namespace PizzaShop.Core.ViewModels.Pizzas
{
    public class IndexViewModel
    {
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
