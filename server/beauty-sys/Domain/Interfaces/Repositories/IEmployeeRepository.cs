using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IQueryable<EmployeeBasicInfo> GetEmployeeBasicInfo();
        ICollection<EmployeeResponse> GetEmployees(int? id, string? name, int currentPage, int takeQuantity);
        Task<bool> HasEmployeeWithSameCpf(string cpf);
    }
}
