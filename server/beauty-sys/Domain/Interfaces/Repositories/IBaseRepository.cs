namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> SaveAsync(T modelObject);
        Task<int> UpdateAsync(T modelObject);
        Task<T?> GetById(int id);
        IQueryable<T> GetAll();
        Task Delete(int id);
    }
}
