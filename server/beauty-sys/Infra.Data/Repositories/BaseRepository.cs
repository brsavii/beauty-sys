using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
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

        public T? GetById(int id)
        {
            return _typedContext.Find(id);
        }

        public void Delete(int id)
        {
            var objeto = GetById(id);
            if (objeto != null)
                _typedContext.Remove(objeto);

            _context.SaveChanges();
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
