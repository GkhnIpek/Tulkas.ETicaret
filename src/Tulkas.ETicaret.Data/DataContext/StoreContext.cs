using Microsoft.EntityFrameworkCore;
using Tulkas.ETicaret.Data.DbModels;

namespace Tulkas.ETicaret.Data.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
