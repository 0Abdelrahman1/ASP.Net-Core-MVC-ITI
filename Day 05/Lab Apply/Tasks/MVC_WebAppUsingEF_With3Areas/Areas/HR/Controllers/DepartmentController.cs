using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_WebAppUsingEF_With3Areas.Areas.HR.Data;
using MVC_WebAppUsingEF_With3Areas.Areas.HR.Models;

namespace MVC_WebAppUsingEF_With3Areas.Areas.HR.Controllers
{
    [Area("HR")]
    public class DepartmentController : Controller
    {
        EmpDeptContext Context = new EmpDeptContext();

        // GET: Department
        public ActionResult Index()
        {
            var departments = Context.Departments.Include(d => d.Employees).ToList();
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var department = Context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.DeptID == id);
            if (department == null)
                return NotFound();
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                if (dept == null)
                    return View();
                Context.Departments.Add(dept);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var department = Context.Departments.FirstOrDefault(d => d.DeptID == id);
            if (department == null)
                return NotFound();
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            var department = Context.Departments.FirstOrDefault(d => d.DeptID == dept.DeptID);
            try
            {
                if (department == null)
                    return NotFound();
                department.Name = dept.Name;
                department.Description = dept.Description;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dept);
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var department = Context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.DeptID == id);
            if (department == null)
                return NotFound();
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Department dept)
        {
            var department = Context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.DeptID == dept.DeptID);
            try
            {
                if (department == null)
                    throw new Exception();
                Context.Remove(department);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(department);
            }
        }
    }
}
