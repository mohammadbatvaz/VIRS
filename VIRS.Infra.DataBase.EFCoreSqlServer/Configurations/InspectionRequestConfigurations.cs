using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.InspectionRequestAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class InspectionRequestConfigurations : IEntityTypeConfiguration<InspectionRequest>
    {
        public void Configure(EntityTypeBuilder<InspectionRequest> builder)
        {
            builder.HasKey(ir => ir.Id);

            builder.HasIndex(ir => ir.TrackingNumber).IsUnique();

            builder.HasOne(ir => ir.Car)
                .WithMany(c => c.InspectionRequests)
                .HasForeignKey(ir => ir.CarId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(ir => ir.CarOwner)
                .WithMany(co => co.inspectionRequests)
                .HasForeignKey(ir => ir.CarOwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(ir => ir.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(ir => ir.IsAcceptable)
                .IsRequired();

            builder.Property(ir => ir.TrackingNumber)
                .HasMaxLength(50);

            builder.HasQueryFilter(ir => !ir.IsDeleted);
        }
    }
}

