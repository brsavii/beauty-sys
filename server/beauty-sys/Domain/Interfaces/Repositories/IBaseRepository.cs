namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> SaveAsync(T modelObject);
        Task<int> UpdateAsync(T modelObject);
    }
}
