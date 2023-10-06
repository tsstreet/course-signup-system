using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class DepartmentDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
