using System.Collections.Generic;
using System.Threading.Tasks;
using Tulkas.ETicaret.Core.DbModels;

namespace Tulkas.ETicaret.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductAsync();
    }
}
