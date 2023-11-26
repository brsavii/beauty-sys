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

        public async Task<T?> GetById(int id)
        {
            return await _typedContext.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var modelObject = await GetById(id)
                ?? throw new InvalidOperationException("Nenhuma entidade encontrada");

            _typedContext.Remove(modelObject);

            _context.SaveChanges();
        }

        public IQueryable<T> GetAll(int currentPage, int takeQuantity)
        {
            if (currentPage < 1)
                throw new InvalidOperationException("A página atual não poder ser menor que 1");

            return _typedContext
                .AsNoTracking()
                .Skip((currentPage - 1) * takeQuantity)
                .Take(takeQuantity);
        }

        public async void Dispose() => await _context.DisposeAsync();
    }
}
