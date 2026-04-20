using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_WebAppEF_ValidationAnnotations.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Total Price Field is Required!")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
