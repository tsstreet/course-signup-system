using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }
        public string? StdCode { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string? ParentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
    }


   
}
