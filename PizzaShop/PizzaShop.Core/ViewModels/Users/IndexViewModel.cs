using PizzaShop.Core.ViewModels.Pagings;
using PizzaShop.Models.Models;
using System.Collections.Generic;


namespace PizzaShop.Core.ViewModels.Users
{
    public class IndexViewModel
    {
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
