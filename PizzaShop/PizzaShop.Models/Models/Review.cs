using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaShop.Models.Models
{
  public  class Review
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Opinion")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Opinion { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        [ForeignKey("PizzaId")]
        public virtual Pizza Pizza { get; set; }
        public int OwnerId { get; set; }
       
        [ForeignKey("OwnerId")]
        [Required]
        public virtual User Owner { get; set; }
    }
}
