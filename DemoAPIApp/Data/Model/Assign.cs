using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPIApp.Data.Model
{
    public class Assign
    {
        [Key]
        public int AsignId { get; set; }

        [Required]
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [Required]
        public string? Room { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string? Day { get; set; }

    }
}
