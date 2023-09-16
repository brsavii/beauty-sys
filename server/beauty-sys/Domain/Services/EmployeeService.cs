using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Objects.Reponses;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeResponse>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeResponse = new List<EmployeeResponse>();

            foreach (var employee in employees)
            {
                employeeResponse.Add(new EmployeeResponse(employee.EmployeeId, employee.Name, employee.Cpf));
            }

            return employeeResponse;
        }
    }
}
