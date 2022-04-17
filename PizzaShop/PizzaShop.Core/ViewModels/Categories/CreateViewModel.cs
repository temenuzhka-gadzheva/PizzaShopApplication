using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Categories
{
    public class CreateViewModel
    {
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

    }
}

