using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Model.Deal
{
    public class DealContext : DbContext 
    {
        public DealContext(DbContextOptions<DealContext> options) : base(options) { }

        public DbSet<Deal> DataEventRecords => Set<Deal>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Deal>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
