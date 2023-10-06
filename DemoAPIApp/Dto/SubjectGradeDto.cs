using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class SubjectGradeDto
    {
  
        [Required]
        public int AcademicYearId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int GradeTypeId { get; set; }

        public int NumOfGradeColumn { get; set; }

        public int NumOfRequireGradeColumn { get; set; }

    }
}
