using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProcedureRepository _procedureRepository;

        public SchedulingService(ISchedulingRepository schedulingRepository, ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IProcedureRepository procedureRepository)
        {
            _schedulingRepository = schedulingRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _procedureRepository = procedureRepository;
        }

        public async Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            var customer = await _customerRepository.GetById(createSchedulingRequest.CustomerId)
                ?? throw new InvalidOperationException("Nenhum cliente encontrado");

            var employeeId = createSchedulingRequest.EmployeeId;
            var procedureId = createSchedulingRequest.ProcedureId;

            var employee = await _employeeRepository.GetById(employeeId)
                ?? throw new InvalidOperationException("Nenhum funcionário encontrado");

            var procedure = await _procedureRepository.GetById(procedureId)
                ?? throw new InvalidOperationException("Nenhum procedimento encontrado");

            var scheduling = new Scheduling
            {
                StartDate = createSchedulingRequest.StartDate,
                Customer = customer,
                Employee = employee,
                Procedure = procedure
            };

            await _schedulingRepository.SaveAsync(scheduling);
        }

        public GetSchedulingsResponse GetSchedulings(int month)
        {
            throw new NotImplementedException();
        }
    }
}
