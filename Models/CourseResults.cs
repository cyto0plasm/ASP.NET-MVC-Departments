using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATwo.Models
{
    public class CourseResults
    {
        [Key]
        public int? Id { get; set; }

        public double? Degree { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        // FK للـ Trainee
        public int? TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public Trainee? Trainee { get; set; }


    }
}
