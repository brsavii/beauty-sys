using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProcedureRepository _procedureRepository;

        public SchedulingService(ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IProcedureRepository procedureRepository)
        {
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _procedureRepository = procedureRepository;
        }

        public Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            var customer = _customerRepository.GetById(createSchedulingRequest.CustomerId);

            var employeeId = createSchedulingRequest.EmployeeId;
            var procedureId = createSchedulingRequest.ProcedureId;

            var employee = _employeeRepository.GetById(createSchedulingRequest.EmployeeId);
            var procedure = _employeeRepository.GetById(createSchedulingRequest.ProcedureId);

            var employeeProcedure = new EmployeeProcedure
            {
                EmployeeId = createSchedulingRequest.EmployeeId,
                ProcedureId = createSchedulingRequest.ProcedureId
            }
        }

        public GetSchedulingsResponse GetSchedulings(int month)
        {
            throw new NotImplementedException();
        }
    }
}
