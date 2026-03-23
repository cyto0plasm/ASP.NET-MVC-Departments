using ATwo.Models;
using ATwo.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATwo.Controllers
{
    public class InstructorController : Controller
    {
        private AppDbContext _db;
        public InstructorController(AppDbContext db) =>_db = db;

        public IActionResult Index()
        {
            var instructors = _db.Instructors.Include(i => i.Department).Include(i => i.Course).ToList();

            return View(instructors);
        }
        public IActionResult Detail(int id)
        {
            var instructorDetails = _db.Instructors.Include(i => i.Department).Include(i => i.Course).FirstOrDefault(i => i.Id == id);
            return View(instructorDetails);
        }
        //public IActionResult Create()
        //{
        //    ViewBag.Departments = _db.Departments.ToList();
        //    ViewBag.Courses = _db.Courses.ToList();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Instructor instructor)
        //{
        //    _db.Instructors.Add(instructor);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }

}
