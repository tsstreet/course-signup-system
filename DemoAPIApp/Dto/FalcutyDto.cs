using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Dto
{
    public class FalcutyDto
    {
        [Key]
        public int FalcutyId { get; set; }

        [Required]
        public string? Name { get; set; }

    }
}
