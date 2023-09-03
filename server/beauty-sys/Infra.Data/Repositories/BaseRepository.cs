using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ConfigContext _context;
        protected readonly DbSet<T> _typedContext;

        public BaseRepository(ConfigContext context)
        {
            _context = context;
            _typedContext = _context.Set<T>();
        }

        public async Task<int> SaveAsync(T modelObject)
        {
            _typedContext.Add(modelObject);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T modelObject)
        {
            _typedContext.Update(modelObject);
            return await _context.SaveChangesAsync();
        }
    }
}
