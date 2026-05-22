using ATwo.Models;
using ATwo.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATwo.Controllers
{
    public class CourseController : Controller
    {
        private AppDbContext _db;
        public CourseController(AppDbContext db) => _db = db;

        // INDEX
        public IActionResult Index(string name)
        {

            if (name == null)
            {

                var courses = _db.Courses
                .Include(c => c.Department)
                .ToList();
                return View(courses);
            }
            else
            {
                var course = _db.Courses
                        .Include(c => c.Department)
                        .Where(c => c.Name.Contains(name))
                        .ToList();
                
                return View(course);
            }            

        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var course = _db.Courses
                .Include(c => c.Department)
                .Include(c => c.Instructors)
                .Include(c => c.CourseResults!)
                .ThenInclude(cr => cr.Trainee)
                .FirstOrDefault(c => c.Id == id);

            if (course == null) return NotFound();
            return View(course);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View(course);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var course = _db.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            ViewBag.Departments = _db.Departments.ToList();
            return View(course);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View(course);
        }

    }
}