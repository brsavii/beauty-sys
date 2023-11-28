using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        ICollection<EmployeeResponse> GetEmployees(int? id, string? name, int currentPage, int takeQuantity);
        Task UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);
        Task CreateEmployee(CreateEmployeeRequest createEmploeeRequest);
        Task DeleteCustomer(int id);
    }
}
