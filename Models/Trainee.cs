using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATwo.Models
{
    public class Trainee
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public double? Grade { get; set; }

        [ForeignKey("depatrmentId")]
        public Department Department { get; set; }

        public List<CourseResults>? CourseResults { get; set; }


    }
}
