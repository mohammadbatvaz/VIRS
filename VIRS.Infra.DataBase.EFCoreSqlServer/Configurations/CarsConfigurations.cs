using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.CarAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class CarsConfigurations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(co => co.VIN)
                .IsUnique();

            builder.HasOne(c => c.CarOwner)
                .WithMany(co => co.Cars)
                .HasForeignKey(c => c.CarOwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(c => c.CarModel)
                .WithMany()
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.OwnsOne(c => c.Plate, plate =>
            {
                plate.Property(p => p.FirstPart)
                    .IsRequired()
                    .HasColumnName("PlateFirstPart")
                    .HasMaxLength(2)
                    .IsUnicode();

                plate.Property(p => p.Letter)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("PlateLetter")
                    .IsUnicode();

                plate.Property(p => p.SecondPart)
                    .IsRequired()
                    .HasColumnName("PlateSecondPart")
                    .HasMaxLength(3)
                    .IsUnicode();

                plate.Property(p => p.ProvinceCode)
                    .IsRequired()
                    .HasColumnName("PlateProvinceCode")
                    .HasMaxLength(2)
                    .IsUnicode();
            });

            builder.Property(c => c.VIN)
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(c => c.ManufactureYear)
                .IsRequired()
                .HasMaxLength(4);
            
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
