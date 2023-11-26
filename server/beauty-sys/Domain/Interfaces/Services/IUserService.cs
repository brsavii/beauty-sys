using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task DeleteUser(int id);
        ICollection<UserResponse> GetUsers(int currentPage, int takeQuantity);
        string LogIn(LogInRequest logInRequest);
        Task SaveUser(CreateUserRequest createCustomerRequest);
        Task UpdateUser(int id, UpdateUserRequest updateUserRequest);
    }
}
