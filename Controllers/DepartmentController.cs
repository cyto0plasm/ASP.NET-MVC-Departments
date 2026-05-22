using ATwo.Models;
using ATwo.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATwo.Controllers
{
    public class DepartmentController : Controller
    {
        private AppDbContext _db;
        public DepartmentController(AppDbContext db) => _db = db;

        // INDEX
        public IActionResult Index(string name)
        {
            var departments = _db.Departments
                .Where(d => string.IsNullOrEmpty(name) || d.Name.Contains(name))
                .ToList();

            ViewData["SearchName"] = name;
            return View(departments);
        }


        // DETAILS
        public IActionResult Details(int id)
        {
            var department = _db.Departments
                .Include(d => d.Instructors)
                .Include(d => d.Trainees)
                .Include(d => d.Courses)
                .FirstOrDefault(d => d.Id == id);

            if (department == null) return NotFound();
            return View(department);
        }

        // CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _db.Departments.FirstOrDefault(d => d.Id == id);
            if (department == null) return NotFound();
            return View(department);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }


    }
}