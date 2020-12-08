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

    }
}
