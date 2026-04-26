using System.ComponentModel.DataAnnotations;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();
    }
}
