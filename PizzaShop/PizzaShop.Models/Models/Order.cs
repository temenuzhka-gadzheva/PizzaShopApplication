using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaShop.Models.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(15)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(20)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "Username")]
        [StringLength(25)]
        public string CustomerUsersname { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address")]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string CustomerPhone { get; set; }
        public DateTime Date { get; set; }
    }
}
