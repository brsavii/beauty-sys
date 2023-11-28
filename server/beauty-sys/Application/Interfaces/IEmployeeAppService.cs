using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface IEmployeeAppService
    {
        Task UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);
    }
}
