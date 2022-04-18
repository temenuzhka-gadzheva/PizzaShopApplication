using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;

namespace PizzaShop.Core.ViewModels.Reviews
{
    public class IndexViewModel
    {
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public virtual ICollection<User> Owners { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
