using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.Core.Interfaces;
using Tulkas.ETicaret.Infrastructure.DataContext;

namespace Tulkas.ETicaret.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            var result = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();

            return result;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
