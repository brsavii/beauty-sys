using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        int? GetUserIdByNameAndPass(string name, string passowd);
    }
}
