using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.DataAccess.Configuration
{
    public class TicketConfig : BaseEntityConfig<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            base.Configure(builder);
        }
    }
}
