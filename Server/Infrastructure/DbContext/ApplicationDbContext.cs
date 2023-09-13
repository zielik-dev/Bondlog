using Bondlog.Server.Infrastructure.Interfaces;
using Bondlog.Shared.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bondlog.Server.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<CollectionsEntity> CollectionsTable { get; set; }
        public DbSet<IncorrectDeliveryEntity> IncorrectDeliveryTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
