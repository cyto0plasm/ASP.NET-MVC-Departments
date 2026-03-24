    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace ATwo.Models
    {
        public class Course
        {
            [Key]
            public int? Id { get; set; }
            public string? Name { get; set; }
            public double? Degree { get; set; }
            public double? MinDegree { get; set; }
            public DateTime? Hrs { get; set; }

            [ForeignKey("depatrmentId")]
            public Department ?Department { get; set; }

            public List<CourseResults>? CourseResults { get; set; }

            public List<Instructor>? Instructors { get; set; }

        }
    }
