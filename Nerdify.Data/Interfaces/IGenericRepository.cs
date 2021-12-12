using Nerdify.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nerdify.Data.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetBooks();
        Task<T> GetBookById(int Id);
    }
}
