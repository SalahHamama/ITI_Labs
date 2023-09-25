using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class EmployeeController : Controller
    {
        private ITIContext db;
        public EmployeeController()
        {
            db = new ITIContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee = db.Employees.Include(e => e.Office).SingleOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return Content("The Employee Not Fuond");
            }
            return View(employee);
        }
        public IActionResult NewForm()
        {
            List<Office> offices = db.Offices.ToList();
            ViewBag.Off = offices;
            return View();
        }
        public IActionResult AddToDB(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult EditForm(int id)
        {
            Employee employee = db.Employees.SingleOrDefault(e => e.Id == id);
            ViewBag.Off = db.Offices.ToList();
            return View(employee);
        }
        public IActionResult EditeInDB(Employee employee)
        {
            Employee OldEmployee = db.Employees.SingleOrDefault(e => e.Id == employee.Id);
            OldEmployee.Name = employee.Name;
            OldEmployee.Email = employee.Email;
            OldEmployee.age = employee.age;
            OldEmployee.Address = employee.Address;
            OldEmployee.Salary = employee.Salary;
            OldEmployee.Password = employee.Password;
            OldEmployee.Office_Id = employee.Office_Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employee employee = db.Employees.SingleOrDefault(e => e.Id == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
