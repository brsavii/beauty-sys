using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        LogInResponse LogIn(LogInRequest logInRequest);
    }
}
