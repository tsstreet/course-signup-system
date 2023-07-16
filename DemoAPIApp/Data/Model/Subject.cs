using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPIApp.Data.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string? SubjectCode { get; set; }

        [Required]
        public string? Name { get; set; }

        //[Required]
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }

        //[Required]
        //[ForeignKey("Falcuty")]
        //public int FalcutyId { get; set; }

        //public ICollection<Teacher> Teachers { get; set; }

    }
}
