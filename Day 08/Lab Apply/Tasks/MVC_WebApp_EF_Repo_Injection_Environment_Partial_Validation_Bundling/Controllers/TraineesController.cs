using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Controllers
{
    public class TraineesController : Controller
    {
        private readonly IBaseRepository<Trainee> _traineeRepository;
        private readonly IBaseRepository<Course> _courseRepository;
        private readonly IBaseRepository<Track> _trackRepository;

        public TraineesController(IBaseRepository<Trainee> traineeRepository, IBaseRepository<Course> courseRepository, IBaseRepository<Track> trackRepository)
        {
            _traineeRepository = traineeRepository;
            _courseRepository = courseRepository;
            _trackRepository = trackRepository;
        }

        // GET: TraineeController
        public ActionResult Index()
        {
            return View(_traineeRepository.GetAll(t => t.Track));
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_traineeRepository.GetById(id, t => t.Track, t => t.TraineeCourses));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), nameof(Track.ID), nameof(Track.Name));
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), nameof(Course.ID), nameof(Course.Topic));
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee freshTrainee)
        {
            ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), nameof(Track.ID), nameof(Track.Name));
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), nameof(Course.ID), nameof(Course.Topic));
            try
            {
                if (!ModelState.IsValid) throw new Exception("Invalid model state");
                _traineeRepository.Add(freshTrainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            var trainee = _traineeRepository.GetById(id, t => t.Track, t => t.TraineeCourses);
            if (trainee == null) return NotFound();
            ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), nameof(Track.ID), nameof(Track.Name), trainee.TrackID);
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), nameof(Course.ID), nameof(Course.Topic), trainee.TraineeCourses?.Select(tc => tc.CourseID));
            return View(trainee);
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainee editedTrainee)
        {
            var trainee = _traineeRepository.GetById(editedTrainee.ID, t => t.Track, t => t.TraineeCourses);
            if (trainee == null) return NotFound();
            ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), nameof(Track.ID), nameof(Track.Name), trainee.TrackID);
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), nameof(Course.ID), nameof(Course.Topic), trainee.TraineeCourses?.Select(tc => tc.CourseID));
            try
            {
                if (!ModelState.IsValid) throw new Exception("Invalid model state");
                _traineeRepository.Update(editedTrainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _traineeRepository.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
