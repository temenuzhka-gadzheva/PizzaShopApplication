using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Ingredients
{
    public class CreateViewModel
    {
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
