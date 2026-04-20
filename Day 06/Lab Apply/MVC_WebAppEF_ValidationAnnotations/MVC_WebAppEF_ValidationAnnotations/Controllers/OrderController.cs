using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_WebAppEF_ValidationAnnotations.Datas;
using MVC_WebAppEF_ValidationAnnotations.Models;

namespace MVC_WebAppEF_ValidationAnnotations.Controllers
{
    public class OrderController : Controller
    {
        OrderManagementContext Context = new OrderManagementContext();

        // GET: OrderController
        public ActionResult Index()
        {
            ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name");
            return View(Context.Orders.Include(o => o.Customer).ToList());
        }

        [HttpPost]
        public ActionResult Index(int selectedCustomerId)
        {
            ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name", selectedCustomerId);
            return View(Context.Orders.Include(o => o.Customer).Where(o => selectedCustomerId == 0 || o.CustID == selectedCustomerId).ToList());
        }


        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(Context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.ID == id));
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order _order)
        {
            try
            {
                if (_order.Date > DateTime.Now) ModelState.AddModelError("Date", "Date cannot be in the future");
                if (!ModelState.IsValid) throw new Exception("Validation failed");
                Context.Orders.Add(_order);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name", _order.CustID);
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name");
            return View(Context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.ID == id));
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order _order)
        {
            try
            {
                if (_order.Date > DateTime.Now) ModelState.AddModelError("Date", "Date cannot be in the future");
                if (!ModelState.IsValid) throw new Exception("Validation failed");
                Context.Orders.Update(_order);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Customers = new SelectList(Context.Customers.ToList(), "ID", "Name", _order.CustID);
                return View(Context.Orders.Include(o => o.Customer).FirstOrDefault(o => o.ID == _order.ID));
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = Context.Orders.FirstOrDefault(o => o.ID == id);
            Context.Orders.Remove(order);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //// POST: OrderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
