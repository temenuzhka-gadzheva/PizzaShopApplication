using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Models
{
  public  class User
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("FirstName")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Username")]
        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Username { get; set; }

        [DisplayName("Password")]
        [StringLength(100, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
