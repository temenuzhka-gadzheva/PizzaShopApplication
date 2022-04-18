using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Reviews
{
    public class EditViewModel: CreateViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}
