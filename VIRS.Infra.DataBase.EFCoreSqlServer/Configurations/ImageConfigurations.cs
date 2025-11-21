using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.ImageAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.InspectionRequest)
                .WithMany(ir => ir.Images)
                .HasForeignKey(i => i.InspectionRequestId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(i => i.ImagePath)
                .IsRequired();

            builder.Property(i => i.InspectionRequestId)
                .IsRequired();
        }
    }
}
