using Domain.Objects.Reponses;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetEmployees();
    }
}
