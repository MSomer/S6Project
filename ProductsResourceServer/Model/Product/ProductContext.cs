using Microsoft.EntityFrameworkCore;

namespace ProductsResourceServer.Model.Product
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> DataEventRecords => Set<Product>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
