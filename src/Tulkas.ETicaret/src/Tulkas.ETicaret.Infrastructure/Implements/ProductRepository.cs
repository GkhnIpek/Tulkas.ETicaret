using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.Core.Interfaces;

namespace Tulkas.ETicaret.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
