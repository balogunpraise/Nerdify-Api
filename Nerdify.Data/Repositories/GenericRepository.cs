using Microsoft.EntityFrameworkCore;
using Nerdify.Data.Interfaces;
using Nerdify.Model;
using Nerdify.Model.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nerdify.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<T> GetBookById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }



        public async Task<ICollection<T>> GetBooks()
        {
            return await _context.Set<T>().ToListAsync();
               
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }


        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
