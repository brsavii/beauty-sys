using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        ICollection<EmployeeResponse> GetEmployees();
        Task<EmployeeResponse> GetById(int id);
        Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest);
        Task CreateEmployee(CreateEmployeeRequest createEmploeeRequest);
    }
}
