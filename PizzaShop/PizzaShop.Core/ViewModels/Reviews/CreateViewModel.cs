using PizzaShop.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Reviews
{
    public class CreateViewModel
    {
        [DisplayName("Opinion")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Opinion { get; set; }
        public DateTime Date => DateTime.UtcNow;
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public int PizzaId { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
        public ICollection<User> Owners { get; set; }
    }
}
