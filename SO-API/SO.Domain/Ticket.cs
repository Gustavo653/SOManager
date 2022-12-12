using SO.Domain.Enum;

namespace SO.Domain
{
    public class Ticket : BaseEntity
    {
        public string Protocol { get; set; }
        public string Subject { get; set; }
        public Complexity Complexity { get; set; }
        public Priority Priority { get; set; }
    }
}
