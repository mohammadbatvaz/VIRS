using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VIRS.Domain.Core.SystemAdminAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Configurations
{
    public class SystemAdminConfigurations : IEntityTypeConfiguration<SystemAdmin>
    {
        public void Configure(EntityTypeBuilder<SystemAdmin> builder)
        {
            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.Username)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(sa => sa.Password)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(sa => sa.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sa => sa.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(sa => sa.Username)
                .IsUnique()
                .HasDatabaseName("IX_SystemAdmins_Username");

            builder.HasQueryFilter(sa => !sa.IsDeleted);
        }
    }
}

