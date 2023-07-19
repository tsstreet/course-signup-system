using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Class> Classes { get; set; }
        //public ICollection<Subject> Subjects { get; set; }
    }
}
