using Bondlog.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bondlog.Server.Infrastructure.Configuration
{
    public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<AspNetUserRolesEntity>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRolesEntity> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.HasKey(r =>  r.RoleId);
        }
    }
}
