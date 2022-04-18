using PizzaShop.Models.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaShop.Core.ViewModels.PizzaIngredients
{
    public class CreateViewModel
    {
        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
