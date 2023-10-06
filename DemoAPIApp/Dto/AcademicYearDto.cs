using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class AcademicYearDto
    {
        [Required]
        public string? AcademicYearCode { get; set; }

        [Required]
        public string? Name { get; set; }   
    }

}
