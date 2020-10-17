using MVCFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinal.Controllers
{
    public class EmployeeDataController : Controller
    {
        public ViewResult GetAllRecords()
        {
            var context = new EmpDatabase();
            var model = context.ETables.ToList();
            return View(model);
        }
        public ViewResult Find(string id)
        {
            int empId = int.Parse(id);
            var context = new EmpDatabase();
            var model = context.ETables.FirstOrDefault((e) => e.ID == empId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(ETable emp)
        {
            var context = new EmpDatabase();
            var model = context.ETables.FirstOrDefault((e) => e.ID == emp.ID);
            model.Name = emp.Name;
            model.Address = emp.Address;
            model.Salary = emp.Salary;
            context.SaveChanges();
            return RedirectToAction("GetAllRecords");
        }
        public ViewResult NewEmployee()
        {
            var model = new ETable();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewEmployee(ETable emp)
        {
            try //Exception Handling for null values
            {
                var context = new EmpDatabase();
                context.ETables.Add(emp);
                context.SaveChanges();
                return RedirectToAction("GetAllRecords");
            }
            catch
            {
                return RedirectToAction("GetAllRecords");
            }
        }
        public ActionResult Delete(string id)
        {
            int empId = int.Parse(id);
            var context = new EmpDatabase();
            var model = context.ETables.FirstOrDefault((e) => e.ID == empId);
            context.ETables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("GetAllRecords");
        }
    }
}