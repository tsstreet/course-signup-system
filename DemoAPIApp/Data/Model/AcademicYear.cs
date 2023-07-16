using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class AcademicYear
    {
        [Key]
        public int AcademicYearId { get; set; }

        [Required]
        public string? AcademicYearCode { get; set; }

        [Required]
        public string? Name { get; set; }

        //public ICollection<Class> Classes { get; set; }        
    }

}
