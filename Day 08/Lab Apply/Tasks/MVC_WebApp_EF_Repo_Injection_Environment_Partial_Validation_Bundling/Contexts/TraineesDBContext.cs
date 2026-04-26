using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts
{
    public class TraineesDBContext : DbContext
    {
        public TraineesDBContext(DbContextOptions<TraineesDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TraineeCourse> TraineeCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========== TRAINEECOURSE - TRAINEE RELATIONSHIP ==========
            modelBuilder.Entity<TraineeCourse>() // Start configuring the TraineeCourse entity
                .HasOne(tc => tc.Trainee) // One TraineeCourse has ONE Trainee
                .WithMany(t => t.TraineeCourses) // One Trainee has MANY TraineeCourses
                .HasForeignKey(tc => tc.TraineeID) // TraineeID is the foreign key in TraineeCourse table
                .OnDelete(DeleteBehavior.Cascade); // If Trainee is deleted, delete all their TraineeCourse records too

            // ========== TRAINEECOURSE - COURSE RELATIONSHIP ==========
            modelBuilder.Entity<TraineeCourse>() // Start configuring the TraineeCourse entity
                .HasOne(tc => tc.Course) // One TraineeCourse has ONE Course
                .WithMany(c => c.TraineeCourses) // One Course has MANY TraineeCourses
                .HasForeignKey(tc => tc.CourseID) // CourseID is the foreign key in TraineeCourse table
                .OnDelete(DeleteBehavior.Cascade); // If Course is deleted, delete all associated TraineeCourse records

            // ========== TRAINEE - TRACK RELATIONSHIP ==========
            modelBuilder.Entity<Trainee>() // Start configuring the Trainee entity
                .HasOne(t => t.Track) // One Trainee has ONE Track
                .WithMany(tr => tr.Trainees) // One Track has MANY Trainees
                .HasForeignKey(t => t.TrackID) // TrackID is the foreign key in Trainee table
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Track if it has Trainees (safer)
        }
    }
}
