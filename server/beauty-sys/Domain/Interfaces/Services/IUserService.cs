using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        string LogIn(LogInRequest logInRequest);
    }
}
