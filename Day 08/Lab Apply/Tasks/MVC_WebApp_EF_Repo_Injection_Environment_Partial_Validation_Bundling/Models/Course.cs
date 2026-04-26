using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; }

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Course Full Mark Grade")]
        public float Grade { get; set; }

        public virtual ICollection<TraineeCourse>? TraineeCourses { get; set; } = new List<TraineeCourse>();
    }
}