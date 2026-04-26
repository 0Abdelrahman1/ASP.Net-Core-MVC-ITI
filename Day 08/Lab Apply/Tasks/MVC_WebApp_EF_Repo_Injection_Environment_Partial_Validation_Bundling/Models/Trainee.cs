using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Track")]
        public int TrackID { get; set; }

        [NotMapped]
        public List<int>? CourseIDs { get; set; }
        public virtual Track? Track { get; set; }

        public virtual ICollection<TraineeCourse>? TraineeCourses { get; set; } = new List<TraineeCourse>();
    }
}