using System.ComponentModel.DataAnnotations;

namespace ATwo.Models
{
    public class Department
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }

     //Relationships 
        public List<Instructor>? Instructors { get; set; }
        public List<Trainee>? Trainees { get; set; }

        public List<Course>? Courses { get; set; }
    }
}
