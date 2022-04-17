using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Categories
{
    public class EditViewModel: CreateViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
