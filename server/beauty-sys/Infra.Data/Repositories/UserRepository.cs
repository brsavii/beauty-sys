using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ConfigContext context) : base(context)
        {
        }

        public int? GetUserIdByNameAndPass(string name, string passowd) => _typedContext.FirstOrDefault(u => u.Name.Equals(name) && u.Password.Equals(passowd))?.UserId;
    }
}
