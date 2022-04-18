using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Pizzas
{
    public class EditViewModel: CreateViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
