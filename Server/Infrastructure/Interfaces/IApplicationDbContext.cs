using Bondlog.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bondlog.Server.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<CollectionsEntity> CollectionsTable { get; set; }
        public DbSet<IncorrectDeliveryEntity> IncorrectDeliveryTable { get; set; }
    }
}
