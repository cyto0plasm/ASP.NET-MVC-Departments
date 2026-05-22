using ATwo.Models;
using ATwo.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATwo.Controllers
{
    public class TraineeController : Controller
    {
        private AppDbContext _db;
        public TraineeController(AppDbContext db) => _db = db;

        // INDEX
        public IActionResult Index(string name)
        {
            var trainees = _db.Trainees
                .Include(t => t.Department)
                .Where(t => string.IsNullOrEmpty(name) || t.Name.Contains(name))
                .ToList();

            ViewData["SearchName"] = name;
            return View(trainees);
        }



        // DETAILS
        public IActionResult Details(int id)
        {
            var trainee = _db.Trainees
       .Include(t => t.Department)
       .Include(t => t.CourseResults!)  
           .ThenInclude(cr => cr.Course)
       .FirstOrDefault(t => t.Id == id);

            if (trainee == null) return NotFound();
            return View(trainee);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Trainee trainee, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(folderPath); // creates folder if it doesn't exist

                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                trainee.Image = "/images/" + fileName;
            }
            //Success
            if (ModelState.IsValid)
            {
                _db.Trainees.Add(trainee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Error
            ViewBag.Departments = _db.Departments.ToList();
            return View(trainee);
        }



        // EDIT GET
        public IActionResult Edit(int id)
        {
            var trainee = _db.Trainees
                .FirstOrDefault(t => t.Id == id);
            
            if (trainee == null) return NotFound();
            ViewBag.Departments = _db.Departments.ToList();
            return View(trainee);
        }

        [HttpPost]
        public IActionResult Edit(Trainee trainee, IFormFile imageFile)
        {
            var existing = _db.Trainees.Find(trainee.Id);
            if (existing == null) return NotFound();

            // update scalar fields
            existing.Name = trainee.Name;
            existing.Address = trainee.Address;
            existing.Grade = trainee.Grade;
            existing.DepartmentId = trainee.DepartmentId;

            //
            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                existing.Image = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _db.Departments.ToList();
            return View(trainee);
        }


    }
}