using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;

namespace PizzaShop.Core.ViewModels.PizzaIngredients
{
    public class IndexViewModel
    {
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
