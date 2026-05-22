using ATwo.Models;
using ATwo.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATwo.Controllers
{
    public class InstructorController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;

        public IActionResult Index(string? name)
        {
            var instructors = _db.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .Where(i => string.IsNullOrEmpty(name) || i.Name.Contains(name))
                .ToList();

            ViewData["SearchName"] = name;
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            var insDetails = _db.Instructors.Include(i => i.Department).Include(i => i.Course).FirstOrDefault(i => i.Id == id);
            return View(insDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            ViewBag.Courses = _db.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _db.Departments.ToList();
                ViewBag.Courses = _db.Courses.ToList();
                return View(instructor);
            }
            _db.Instructors.Add(instructor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = _db.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            ViewBag.Departments = _db.Departments.ToList();
            ViewBag.Courses = _db.Courses.ToList();
            return View(instructor);
        }

        [HttpPost]
    public IActionResult Edit(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _db.Departments.ToList();
                ViewBag.Courses = _db.Courses.ToList();
                return View(instructor);
            }
            _db.Instructors.Update(instructor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }

    }
