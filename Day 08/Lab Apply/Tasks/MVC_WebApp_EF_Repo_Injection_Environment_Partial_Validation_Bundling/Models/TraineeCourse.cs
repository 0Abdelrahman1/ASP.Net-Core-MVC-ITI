using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models
{
    [PrimaryKey(nameof(TraineeID), nameof(CourseID))]
    public class TraineeCourse
    {
        [Required]
        public int TraineeID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        [Range(0, 100)]
        public float Grade { get; set; }

        public virtual Trainee? Trainee { get; set; }
        public virtual Course? Course { get; set; }

        public override bool Equals(object? obj) =>
            obj is TraineeCourse other &&
            TraineeID == other.TraineeID &&
            CourseID == other.CourseID;

        public override int GetHashCode() =>
            HashCode.Combine(TraineeID, CourseID);
    }
}