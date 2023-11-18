using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public Task<string> LogIn()
        {
            throw new NotImplementedException();
        }
    }
}
