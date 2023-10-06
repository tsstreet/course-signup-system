using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class FalcutyDto
    {
        [Required]
        public string? Name { get; set; }

    }
}
