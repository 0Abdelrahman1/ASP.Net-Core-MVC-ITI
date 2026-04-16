using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        public ActionResult Index()
        {
            return View(CarList.cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(CarList.cars.FirstOrDefault(c => c.Num == id));
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View(new Car());
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            car.Num = CarList.cars.Count > 0 ? CarList.cars.Max(c => c.Num) + 1 : 1;
            CarList.cars.Add(car);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CarList.cars.FirstOrDefault(c => c.Num == id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car updCar)
        {
            var car = CarList.cars.FirstOrDefault(c => c.Num == updCar.Num);
            if (car != null)
            {
                car.Manufacturer = updCar.Manufacturer;
                car.Model = updCar.Model;
                car.Color = updCar.Color;
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            var car = CarList.cars.FirstOrDefault(c => c.Num == id);
            if (car != null)
                CarList.cars.Remove(car);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
