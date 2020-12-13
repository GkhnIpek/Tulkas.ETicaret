using System.Collections.Generic;
using System.Threading.Tasks;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.Core.Specifications;

namespace Tulkas.ETicaret.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
