using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SO.DataAccess.Configuration;
using SO.Domain;
using SO.Domain.Identity;
using System;

namespace SO.DataAccess
{
    public class SOContext : IdentityDbContext<User, Role, Guid,
                                               IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
                                               IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<Ticket> Tickets { get; set; }
        public SOContext(DbContextOptions<SOContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );

            modelBuilder.ApplyConfiguration(new TicketConfig());
        }
    }
}