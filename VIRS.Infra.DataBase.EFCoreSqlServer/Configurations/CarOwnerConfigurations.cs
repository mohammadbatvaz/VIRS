using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.CarOwnerAgg.DTOs;
using VIRS.Domain.Core.CarOwnerAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class CarOwnerConfigurations : IEntityTypeConfiguration<CarOwner>
    {
        public void Configure(EntityTypeBuilder<CarOwner> builder)
        {
            builder.HasKey(co => co.Id);

            builder.HasIndex(co => co.NID)
                .IsUnique();

            builder.Property(co => co.NID)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(co => co.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(co => co.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(co => co.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasQueryFilter(co => !co.IsDeleted);
        }
    }
}

