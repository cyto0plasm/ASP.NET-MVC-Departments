using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATwo.Models
{
    public class Instructor
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? Salary { get; set; }
        public string? Address { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

    }
}
