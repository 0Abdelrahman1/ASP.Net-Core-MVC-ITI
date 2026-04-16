using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class CarController : Controller
    {
        public IActionResult GetAllCars()
        {
            ViewBag.Cars = CarList.cars;
            return View();
        }
        public IActionResult SelectCarById(int Id)
        {
            ViewBag.Car = CarList.cars.FirstOrDefault(c => c.Num == Id);
            return ViewBag.Car != null ? View() : NotFound();
        }
        public IActionResult CreateNewCar()
        {
            return View();
        }
        public IActionResult InsertNew(string manufacturer, string model, string color)
        {
            int newNum = CarList.cars.Max(c => c.Num) + 1;
            CarList.cars.Add(new() { Num = newNum, Manufacturer = manufacturer, Model = model, Color = color });
            return RedirectToAction("GetAllCars");
        }

        public IActionResult EditCar(int Id)
        {
            ViewBag.Car = CarList.cars.FirstOrDefault(c => c.Num == Id);
            return ViewBag.Car != null ? View() : NotFound();
        }

        public IActionResult UpdateCar(int Num, string manufacturer, string model, string color)
        {
            var car = CarList.cars.FirstOrDefault(c => c.Num == Num);
            if (car != null)
            {
                car.Manufacturer = manufacturer;
                car.Model = model;
                car.Color = Request.Form["Color"];
            }
            return RedirectToAction("GetAllCars");
        }

        public IActionResult DeleteCar(int Id)
        {
            var car = CarList.cars.FirstOrDefault(c => c.Num == Id);
            if (car != null)
                CarList.cars.Remove(car);
            return RedirectToAction("GetAllCars");
        }
    }
}
