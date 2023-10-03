using Bondlog.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bondlog.Server.Infrastructure.Configuration
{
    public class CollectionsConfiguration : IEntityTypeConfiguration<CollectionsEntity>
    {
        public void Configure(EntityTypeBuilder<CollectionsEntity> builder)
        {
            builder.HasKey(c => c.Id);
            //builder.Property(c => c.Name).HasColumnType("varchar(250)").IsRequired();;
            //more to build
        }
    }
}
