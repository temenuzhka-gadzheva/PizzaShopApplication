using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;

namespace PizzaShop.Core.ViewModels.Categories
{
    public class IndexViewModel
    {
        public virtual ICollection<Category> Categories { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
