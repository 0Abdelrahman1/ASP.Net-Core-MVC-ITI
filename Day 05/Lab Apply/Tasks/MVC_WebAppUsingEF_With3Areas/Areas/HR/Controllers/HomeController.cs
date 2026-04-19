using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_WebAppUsingEF_With3Areas.Areas.HR.Data;
using MVC_WebAppUsingEF_With3Areas.Areas.HR.Models;

namespace MVC_WebAppUsingEF_With3Areas.Areas.HR.Controllers
{
    [Area("HR")]
    public class HomeController : Controller
    {
        EmpDeptContext Context = new EmpDeptContext();
        // GET: HomeController
        public ActionResult Index()
        {
            ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name");
            var employees = Context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }

        [HttpPost]
        public ActionResult Index(int selectedDepartmentId)
        {
            Console.WriteLine(selectedDepartmentId);
            ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name", selectedDepartmentId);
            var employees = Context.Employees.Include(e => e.Department).Where(e => selectedDepartmentId == 0 || e.DeptID == selectedDepartmentId).ToList();
            return View(employees);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = Context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpID == id);
            return View(employee);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name");
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name");
            try
            {
                if (emp == null)
                    return View();
                Context.Employees.Add(emp);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = Context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpID == id);
            ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name", employee.DeptID);
            return View(employee);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            var employee = Context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpID == emp.EmpID);
            try
            {
                employee.Name = emp.Name;
                employee.Password = emp.Password;
                employee.JoinDate = emp.JoinDate;
                employee.Email = emp.Email;
                employee.PhoneNum = emp.PhoneNum;
                employee.DeptID = emp.DeptID;
                employee.Department = Context.Departments.FirstOrDefault(d => d.DeptID == emp.DeptID);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Depts = new SelectList(Context.Departments.ToList(), "DeptID", "Name", emp.DeptID);
                return View(emp);
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = Context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpID == id);
            return View(employee);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee emp)
        {
            var employee = Context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmpID == emp.EmpID);
            try
            {
                if (employee == null) throw new Exception();
                Context.Remove(employee);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }
    }
}
