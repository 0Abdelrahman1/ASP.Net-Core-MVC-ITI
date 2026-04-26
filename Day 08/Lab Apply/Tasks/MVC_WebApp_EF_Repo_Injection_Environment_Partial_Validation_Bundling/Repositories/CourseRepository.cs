using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using System.Linq.Expressions;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories
{
    public class CourseRepository : IBaseRepository<Course>
    {
        private readonly TraineesDBContext _context;
        public CourseRepository(TraineesDBContext context) { _context = context; }

        public void Add(Course entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Courses.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.ID == id);
            if (course == null) throw new KeyNotFoundException($"No course found with ID {id}.");
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        public List<Course> GetAll(params Expression<Func<Course, object>>[] includes)
        {
            var query = _context.Courses.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.ToList();
        }

        public Course GetById(int id, params Expression<Func<Course, object>>[] includes)
        {
            var query = _context.Courses.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            var course = query.FirstOrDefault(c => c.ID == id);
            if (course == null) throw new KeyNotFoundException($"No course found with ID {id}.");
            return course;
        }

        public void Update(Course entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var course = _context.Courses.FirstOrDefault(c => c.ID == entity.ID);
            if (course == null) throw new KeyNotFoundException($"No course found with ID {entity.ID}.");
            _context.Entry(course).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}