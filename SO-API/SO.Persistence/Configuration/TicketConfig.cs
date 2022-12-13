using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.Domain;

namespace SO.DataAccess.Configuration
{
    public class TicketConfig : BaseEntityConfig<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            base.Configure(builder);

            builder.HasIndex(p => new { p.Protocol }).IsUnique();
            builder.Property(x => x.Complexity).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
        }
    }
}
