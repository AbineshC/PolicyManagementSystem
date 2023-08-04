using Microsoft.EntityFrameworkCore;
using Assignment.Contracts.Data.Entities;
using Policy_Management_System_API;

namespace Assignment.Migrations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                item.Entity.AddedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<App> App { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Policy> PolicyInformation { get; set; }
        public DbSet<PolicyType> PolicyTypeenum { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ApprovalHistory> ApprovalHistory { get; set; }
        //public DbSet<VehicleDetail> VehicleDetail { get; set; }
        //public DbSet<HouseDetail> HouseDetail { get; set; }
    }
}