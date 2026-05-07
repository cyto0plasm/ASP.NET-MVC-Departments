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
       
    }

}
