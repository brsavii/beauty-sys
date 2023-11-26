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
            if (!ValidateCpf(createEmployeeRequest.Cpf))
                throw new InvalidOperationException("CPF Inválido");

            if (await _employeeRepository.HasEmployeeWithSameCpf(createEmployeeRequest.Cpf))
                throw new InvalidOperationException("Já existe um funcionário com esse CPF");

            var employee = new Employee
            {
                Name = createEmployeeRequest.Name,
                Office = createEmployeeRequest.Office,
                Cpf = createEmployeeRequest.Cpf,
                InsertedAt = DateTime.Now
            };

            await _employeeRepository.SaveAsync(employee);
        }

        public ICollection<EmployeeResponse> GetEmployees(int currentPage, int takeQuantity = 10)
        {
            var employees = _employeeRepository.GetAll(currentPage, takeQuantity);

            if (!employees.Any())
                throw new InvalidOperationException("Nenhum funcionário encontrado");

            var employeeResponse = new List<EmployeeResponse>();

            foreach (var employee in employees)
            {
                employeeResponse.Add(new EmployeeResponse(employee.EmployeeId, employee.Name, employee.Cpf, employee.Office));
            }

            return employeeResponse;
        }

        public async Task UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await _employeeRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum cliente encontrado.");

            if (updateEmployeeRequest.Name != null)
                employee.Name = updateEmployeeRequest.Name;

            if (updateEmployeeRequest.Office != null)
                employee.Office = updateEmployeeRequest.Office;

            employee.UpdatedAt = DateTime.Now;

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteCustomer(int id) => await _employeeRepository.Delete(id);

        private static bool ValidateCpf(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            var tempCpf = cpf[..9];
            var soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
