using DemoAPIApp.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPIApp.Data.Dto
{
    public class ScheduleDto
    {
        [Required]
        public int ClassId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public string? Room { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeStart { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeEnd { get; set; }

        [Required]
       

        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string? Day { get; set; }

    }
}
