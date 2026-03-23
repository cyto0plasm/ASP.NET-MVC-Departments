using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATwo.Models
{
    public class CourseResults
    {
        [Key]
        public int? Id { get; set; }

        public double? Degree { get; set; }

        [ForeignKey("courseId")]
        public Course ?Course { get; set; }
        [ForeignKey("traineeId")]
        public Trainee ?Trainee { get; set; }


    }
}
