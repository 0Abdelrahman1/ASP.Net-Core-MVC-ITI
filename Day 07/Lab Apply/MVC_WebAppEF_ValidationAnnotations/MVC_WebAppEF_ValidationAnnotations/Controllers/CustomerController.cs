using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_WebAppEF_ValidationAnnotations.Datas;
using MVC_WebAppEF_ValidationAnnotations.Models;

namespace MVC_WebAppEF_ValidationAnnotations.Controllers
{
    public class CustomerController : Controller
    {
        OrderManagementContext Context = new OrderManagementContext();
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(Context.Customers.ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(Context.Customers.FirstOrDefault(c => c.ID == id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer _customer)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Model is not valid");
                Context.Add(_customer);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Context.Customers.FirstOrDefault(c => c.ID == id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer _customer)
        {
            var customer = Context.Customers.FirstOrDefault(c => c.ID == _customer.ID);
            try
            {
                if (!ModelState.IsValid) throw new Exception("Model is not valid");
                customer.Name = _customer.Name;
                customer.Email = _customer.Email;
                customer.PhoneNum = _customer.PhoneNum;
                customer.Gender = _customer.Gender;
                customer.Orders = _customer.Orders;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_customer);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Context.Customers.FirstOrDefault(c => c.ID == id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer _customer)
        {
            var customer = Context.Customers.FirstOrDefault(c => c.ID == _customer.ID);
            try
            {
                Context.Remove(customer);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
