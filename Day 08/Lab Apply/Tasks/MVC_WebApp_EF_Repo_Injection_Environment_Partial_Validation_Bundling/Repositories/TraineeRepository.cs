using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using System.Linq.Expressions;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories
{
    public class TraineeRepository : IBaseRepository<Trainee>
    {
        private readonly TraineesDBContext _context;
        public TraineeRepository(TraineesDBContext context) { _context = context; }

        public void Add(Trainee entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Trainees.Add(entity);
            _context.SaveChanges();

            _context.TraineeCourses.AddRange(entity.CourseIDs?.Select(courseId => new TraineeCourse()
            {
                TraineeID = entity.ID,
                CourseID = courseId
            }).ToList() ?? new List<TraineeCourse>());
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var trainee = _context.Trainees.FirstOrDefault(t => t.ID == id);
            if (trainee == null) throw new KeyNotFoundException($"No trainee found with ID {id}.");
            
            _context.Trainees.Remove(trainee);
            _context.SaveChanges();
        }

        public List<Trainee> GetAll(params Expression<Func<Trainee, object>>[] includes)
        {
            var query = _context.Trainees.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.ToList();
        }

        public Trainee GetById(int id, params Expression<Func<Trainee, object>>[] includes)
        {
            var query = _context.Trainees.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            var trainee = query.FirstOrDefault(t => t.ID == id);
            if (trainee == null) throw new KeyNotFoundException($"No trainee found with ID {id}.");
            return trainee;
        }

        public void Update(Trainee entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var trainee = _context.Trainees.FirstOrDefault(t => t.ID == entity.ID);
            if (trainee == null) throw new KeyNotFoundException($"No trainee found with ID {entity.ID}.");
            
            _context.Entry(trainee).CurrentValues.SetValues(entity);
            
            var oldCourses = _context.TraineeCourses.Where(tc => tc.TraineeID == entity.ID).ToList();
            var newCourses = entity.CourseIDs?.Select(ci => new TraineeCourse() { TraineeID = entity.ID, CourseID = ci }).ToList() ?? new List<TraineeCourse>();
            _context.TraineeCourses.RemoveRange(oldCourses.Except(newCourses).ToList());
            _context.TraineeCourses.AddRange(newCourses.Except(oldCourses).ToList());
            _context.SaveChanges();
        }
    }
}