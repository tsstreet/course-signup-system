using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPIApp.Data.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [ForeignKey("AcademicYear")]
        public int AcaYearId { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [Required]
        public string? ClassName { get; set; }

        [Required]
        public string? NumOfStd { get; set; }

        [Required]
        public decimal Tuition { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool Active { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
