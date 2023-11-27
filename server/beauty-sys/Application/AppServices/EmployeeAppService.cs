using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;

namespace Application.AppServices
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            if (updateEmployeeRequest.Name == null && updateEmployeeRequest.Office == null && updateEmployeeRequest.JobPositionId == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            await _employeeService.UpdateEmployee(id, updateEmployeeRequest);
        }
    }
}
