using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;
using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.CarModelAgg.Entities;
using VIRS.Domain.Core.CarOwnerAgg.Entities;
using VIRS.Domain.Core.ImageAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Entities;
using VIRS.Domain.Core.SystemAdminAgg.Entities;

namespace VIRS.Infra.DataBase.EFCoreSqlServer
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<SystemAdmin> SystemsAdmins { get; set; }
        public DbSet<Image> Images { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.Now;

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
