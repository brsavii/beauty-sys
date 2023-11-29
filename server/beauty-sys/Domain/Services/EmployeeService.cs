using AutoMapper;
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
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IJobPositionRepository jobPositionRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _jobPositionRepository = jobPositionRepository;
            _mapper = mapper;
        }

        public async Task CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            if (!ValidateCpf(createEmployeeRequest.Cpf))
                throw new InvalidOperationException("CPF Inválido");

            if (await _employeeRepository.HasEmployeeWithSameCpf(createEmployeeRequest.Cpf))
                throw new InvalidOperationException("Já existe um funcionário com esse CPF");

            var jobPosition = await _jobPositionRepository.GetById(createEmployeeRequest.JobPositionId)
                ?? throw new InvalidOperationException("Nenhum cargo encontrado");

            var employee = _mapper.Map<Employee>(createEmployeeRequest);
            employee.JobPosition = jobPosition;

            await _employeeRepository.SaveAsync(employee);
        }

        public ICollection<EmployeeResponse> GetEmployees(int? id, string? name, int currentPage, int takeQuantity)
        {
            var employees = _employeeRepository.GetEmployees(id, name, currentPage, takeQuantity);

            if (!employees.Any())
                throw new InvalidOperationException("Nenhum funcionário encontrado");

            return employees;
        }

        public async Task UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await _employeeRepository.GetById(updateEmployeeRequest.EmployeeId) ?? throw new InvalidOperationException("Nenhum cliente encontrado.");

            if (updateEmployeeRequest.Name != null)
                employee.Name = updateEmployeeRequest.Name;

            if (updateEmployeeRequest.JobPositionId != null)
            {
                var jobPosition = await _jobPositionRepository.GetById(updateEmployeeRequest.JobPositionId.Value)
                    ?? throw new InvalidOperationException("Nenhum cargo encontrado");

                employee.JobPosition = jobPosition;
            }

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
