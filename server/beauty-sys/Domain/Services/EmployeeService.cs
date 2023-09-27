using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            var employee = new Employee
            {
                Name = createEmployeeRequest.Name,
                Office = createEmployeeRequest.Office,
                Cpf = createEmployeeRequest.Cpf,
            };

            employee.InsertedAt = DateTime.Now;
            await _employeeRepository.SaveAsync(employee);
        }
        public async Task<EmployeeResponse> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum funcionário encontrado.");

            var employeeResponse = new EmployeeResponse(employee.EmployeeId, employee.Name, employee.Cpf, employee.Office);

            return employeeResponse;
        }
        public async Task<List<EmployeeResponse>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeResponse = new List<EmployeeResponse>();

            foreach (var employee in employees)
            {
                employeeResponse.Add(new EmployeeResponse(employee.EmployeeId, employee.Name, employee.Cpf, employee.Office));
            }

            return employeeResponse;
        }

    }
}
