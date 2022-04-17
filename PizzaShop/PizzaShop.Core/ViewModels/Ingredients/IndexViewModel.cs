using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;

namespace PizzaShop.Core.ViewModels.Ingredients
{
    public class IndexViewModel
    {
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
