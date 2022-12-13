using Common.DataAccess;
using SO.Domain;
using SO.Infrastructure;

namespace SO.DataAccess.Repository
{
    public class TicketRepository : BaseRepository<Ticket, SOContext>, ITicketRepository
    {
        public TicketRepository(SOContext context) : base(context)
        {
        }
    }
}
