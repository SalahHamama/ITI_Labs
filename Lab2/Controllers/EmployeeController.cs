using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

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
            Employee employee = db.Employees.Where(e => e.Id == id).SingleOrDefault();
            if(employee == null)
            {
                return Content("The Employee Not Fuond");
            }
            return View(employee);
        }
        public IActionResult NewForm()
        {
            return View();
        }
        public IActionResult AddToDB(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
