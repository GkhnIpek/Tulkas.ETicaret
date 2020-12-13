using Microsoft.EntityFrameworkCore;
using Tulkas.ETicaret.Core.DbModels;

namespace Tulkas.ETicaret.Infrastructure.DataContext
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductBrand)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(c => c.Products);
        }
    }

    
}
