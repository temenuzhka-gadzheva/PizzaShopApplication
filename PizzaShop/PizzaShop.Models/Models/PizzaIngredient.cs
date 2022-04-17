using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models.Models
{
   public class PizzaIngredient
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }
        
        [ForeignKey("PizzaId")]
        public virtual Pizza Pizza { get; set; }


        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }
       
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }
    }
}
