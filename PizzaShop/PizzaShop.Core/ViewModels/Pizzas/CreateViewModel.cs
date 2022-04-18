using PizzaShop.Models.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Pizzas
{
    public class CreateViewModel
    {
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}
