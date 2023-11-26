using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        ICollection<EmployeeResponse> GetEmployees(int currentPage, int takeQuantity = 10);
        Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest);
        Task CreateEmployee(CreateEmployeeRequest createEmploeeRequest);
        Task DeleteCustomer(int id);
    }
}
