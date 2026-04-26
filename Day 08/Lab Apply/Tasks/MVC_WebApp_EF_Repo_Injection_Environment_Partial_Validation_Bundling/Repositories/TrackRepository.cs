using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using System.Linq.Expressions;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories
{
    public class TrackRepository : IBaseRepository<Track>
    {
        private readonly TraineesDBContext _context;

        public TrackRepository(TraineesDBContext context) { _context = context; }

        public void Add(Track entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Tracks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var track = _context.Tracks.FirstOrDefault(t => t.ID == id);
            if (track == null) throw new KeyNotFoundException($"No track found with ID {id}.");
            _context.Tracks.Remove(track);
            _context.SaveChanges();
        }

        public List<Track> GetAll(params Expression<Func<Track, object>>[] includes)
        {
            var query = _context.Tracks.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.ToList();
        }

        public Track GetById(int id, params Expression<Func<Track, object>>[] includes)
        {
            var query = _context.Tracks.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            var track = query.FirstOrDefault(t => t.ID == id);
            if (track == null) throw new KeyNotFoundException($"No track found with ID {id}.");
            return track;
        }

        public void Update(Track entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var track = _context.Tracks.FirstOrDefault(t => t.ID == entity.ID);
            if (track == null) throw new KeyNotFoundException($"No track found with ID {entity.ID}.");
            _context.Entry(track).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}