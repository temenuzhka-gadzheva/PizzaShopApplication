using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models.Models
{
  public  class Pizza
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

        [Range(0.00, ((double)decimal.MaxValue), ErrorMessage = "Must be a positive number")]
        [Required]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

        [DisplayName("Select Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
