using Nerdify.Model;
using Nerdify.Model.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nerdify.Data.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetBooks();
        Task<T> GetBookById(int Id);
        Task<T> GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec);
    }
}
