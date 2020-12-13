using Microsoft.Extensions.DependencyInjection;
using Tulkas.ETicaret.Core.Interfaces;
using Tulkas.ETicaret.Infrastructure.Implements;

namespace Tulkas.ETicaret.WebAPI.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
