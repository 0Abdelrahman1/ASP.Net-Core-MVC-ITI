using System.ComponentModel.DataAnnotations;

namespace MVC_WebAppEF_ValidationAnnotations.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name Field is Required!")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Email Field is Required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "Phone number cannot exceed 11 characters.")]
        [LocalPhoneNumber]
        public string PhoneNum { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
