using Domain.Objects.Reponses;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> LogIn();
    }
}
