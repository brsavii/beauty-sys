using Domain.Models;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IQueryable<EmployeeBasicInfo> GetEmployeeBasicInfo();
        Task<bool> HasEmployeeWithSameCpf(string cpf);
    }
}
