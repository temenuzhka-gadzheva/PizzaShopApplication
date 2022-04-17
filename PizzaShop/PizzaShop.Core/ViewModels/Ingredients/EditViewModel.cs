using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Ingredients
{
    public class EditViewModel: CreateViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
