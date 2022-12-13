using SO.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SO.DTO
{
    public class TicketDTO
    {
        [Required]
        public string Protocol { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Range(0, 2)]
        public Complexity Complexity { get; set; }
        [Required]
        [Range(0, 2)]
        public Priority Priority { get; set; }
    }
}
