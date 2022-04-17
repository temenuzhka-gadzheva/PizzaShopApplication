using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Core.ViewModels.Home
{
    public class RegisterViewModel: LoginViewModel
    {
        [DisplayName("FirstName")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string LastName { get; set; }
    }
}
