using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tulkas.ETicaret.Infrastructure.DataContext
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../../Tulkas.ETicaret.WebAPI/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<StoreDbContext>();
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            builder.UseSqlServer(connectionString);

            return new StoreDbContext(builder.Options);
        }
    }
}
