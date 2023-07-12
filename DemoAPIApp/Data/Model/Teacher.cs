using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string? TeacherCode { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }


        public string? Address { get; set; }

        [Required]
        public string? Phone { get; set; }
        [Required] 
        public string? Email { get; set; }

        public string? ImageUrl { get; set; }
        public string? Class { get; set;}
        public string? Password { get; set; }
    }
   
}
