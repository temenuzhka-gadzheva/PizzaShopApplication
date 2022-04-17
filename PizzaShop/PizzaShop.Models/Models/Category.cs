using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Models
{
  public  class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]

        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Required]

        public string Description { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
