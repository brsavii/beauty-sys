using Domain.Models;
using Domain.Objects.Reponses;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        int? GetUserIdByNameAndPass(string name, string passowd);
        ICollection<UserResponse> GetUsers(int? id, string? name, int currentPage, int takeQuantity);
        Task<bool> HasUserWithSameName(string name);
    }
}
