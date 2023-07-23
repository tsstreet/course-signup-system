using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class AcademicYearDto
    {
        [Key]
        public int AcademicYearId { get; set; }

        [Required]
        public string? AcademicYearCode { get; set; }

        [Required]
        public string? Name { get; set; }   
    }

}
