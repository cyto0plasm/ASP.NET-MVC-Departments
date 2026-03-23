using System.ComponentModel.DataAnnotations;

namespace ATwo.Models
{
    public class Department
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }


        public List<Instructor>? Instructors { get; set; }
        public List<Trainee>? Trainee { get; set; }

        public List<Course>? Course { get; set; }
    }
}
