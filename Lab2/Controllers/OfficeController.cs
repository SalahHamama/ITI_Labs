using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab4.Controllers
{
    public class OfficeController : Controller
    {
        private ITIContext db;
        public OfficeController()
        {
            db = new ITIContext();
        }
        public IActionResult Index()
        {
            List<Office> offices = db.Offices.ToList();
            return View(offices);
        }
        public IActionResult Details(int id)
        {
            Office office = db.Offices.SingleOrDefault(i => i.Id == id);
            return View(office);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Office office)
        {
            db.Offices.Add(office);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Office office = db.Offices.SingleOrDefault(i => i.Id == id);
            return View(office);
        }
        [HttpPost]
        public IActionResult Edit(Office office)
        {
            db.Offices.Update(office);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Office office = db.Offices.SingleOrDefault(i => i.Id == id);

            db.Offices.Remove(office);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
