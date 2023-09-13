using Bondlog.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bondlog.Server.Infrastructure.Configuration
{
    public class IncorrectDeliveryConfiguration : IEntityTypeConfiguration<IncorrectDeliveryEntity>
    {
        public void Configure(EntityTypeBuilder<IncorrectDeliveryEntity> builder)
        {
            //AuditableEntity
            builder.HasKey(i => i.Id);
            builder.Property(i => i.CreatedBy).HasColumnType("varchar(250)");
            builder.Property(d => d.CreatedDate).HasColumnType("smalldatetime");
            builder.Property(d => d.ModifiedBy).HasColumnType("varchar(250)");
            builder.Property(d => d.ModifiedDate).HasColumnType("smalldatetime");
            builder.Property(d => d.InactivatedBy).HasColumnType("varchar(250)");
            builder.Property(d => d.InactivatedDate).HasColumnType("smalldatetime");
            builder.Property(d => d.StatusId).HasColumnType("int");
            //IncorrectDeliveryEntity
            builder.Property(d => d.TransactionReference).HasColumnType("varchar(250)");
            builder.Property(d => d.Contract).HasColumnType("varchar(250)");
            builder.Property(d => d.Site).HasColumnType("varchar(250)");
            builder.Property(d => d.Department).HasColumnType("varchar(250)");
            builder.Property(d => d.DeliveryReference).HasColumnType("varchar(250)");
            builder.Property(d => d.PurchaseOrderReference).HasColumnType("varchar(250)");
            builder.Property(d => d.Type).HasColumnType("varchar(250)");
            builder.Property(d => d.Supplier).HasColumnType("varchar(250)");
            builder.Property(d => d.ExpectedSku).HasColumnType("varchar(250)");
            builder.Property(d => d.ExpectedQty).HasColumnType("varchar(250)");
            builder.Property(d => d.ReceivedSku).HasColumnType("varchar(250)");
            builder.Property(d => d.ReceivedQty).HasColumnType("varchar(250)");
            builder.Property(d => d.Escalation).HasColumnType("varchar(250)");
            builder.Property(d => d.PlannerName).HasColumnType("varchar(250)");
            builder.Property(d => d.Details).HasColumnType("varchar(250)");
            builder.Property(d => d.WorkAround).HasColumnType("varchar(250)");
            builder.Property(d => d.CurrentAction).HasColumnType("varchar(250)");
        }
    }
}
