using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Controllers
{
    public class TraineeCoursesController : Controller
    {
        private readonly TraineesDBContext _context;

        public TraineeCoursesController(TraineesDBContext context)
        {
            _context = context;
        }

        // GET: TraineeCourses
        public async Task<IActionResult> Index()
        {
            var traineesDBContext = _context.TraineeCourses.Include(t => t.Course).Include(t => t.Trainee);
            return View(await traineesDBContext.ToListAsync());
        }

        // GET: TraineeCourses/Details/5
        public async Task<IActionResult> Details(int CourseId, int TraineeId)
        {
            var traineeCourse = await _context.TraineeCourses
                .Include(t => t.Course)
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(m => m.CourseID == CourseId && m.TraineeID == TraineeId);
            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // GET: TraineeCourses/Create
        public IActionResult Create()
        {
            ViewBag.CourseID = new SelectList(_context.Courses, "ID", "Topic");
            ViewBag.TraineeID = new SelectList(_context.Trainees, "ID", "Name");
            return View();
        }

        // POST: TraineeCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traineeCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CourseID = new SelectList(_context.Courses, "ID", "Topic", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(_context.Trainees, "ID", "Name", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Edit/5
        public async Task<IActionResult> Edit(int CourseId, int TraineeId)
        {
            var traineeCourse = await _context.TraineeCourses.FirstOrDefaultAsync(tc => tc.TraineeID == TraineeId && tc.CourseID == CourseId);
            if (traineeCourse == null)
            {
                return NotFound();
            }
            ViewBag.CourseID = new SelectList(_context.Courses, "ID", "Topic", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(_context.Trainees, "ID", "Name", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // POST: TraineeCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traineeCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeCourseExists(traineeCourse.TraineeID, traineeCourse.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CourseID = new SelectList(_context.Courses, "ID", "Topic", traineeCourse.CourseID);
            ViewBag.TraineeID = new SelectList(_context.Trainees, "ID", "Name", traineeCourse.TraineeID);
            return View(traineeCourse);
        }

        // GET: TraineeCourses/Delete/5
        public async Task<IActionResult> Delete(int TraineeID, int CourseID)
        {
            var traineeCourse = await _context.TraineeCourses
                .Include(t => t.Course)
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(m => m.TraineeID == TraineeID && m.CourseID == CourseID);
            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // POST: TraineeCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TraineeCourse traineeCourse)
        {
            var traineeCourseToDelete = await _context.TraineeCourses.FindAsync(traineeCourse.TraineeID, traineeCourse.CourseID);
            if (traineeCourseToDelete != null)
            {
                _context.TraineeCourses.Remove(traineeCourseToDelete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeCourseExists(int TraineeID, int CourseID)
        {
            return _context.TraineeCourses.Any(e => e.TraineeID == TraineeID && e.CourseID == CourseID);
        }
    }
}
