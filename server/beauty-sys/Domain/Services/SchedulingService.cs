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
                Procedure = procedure,
                InsertedAt = DateTime.Now
            };

            await _schedulingRepository.SaveAsync(scheduling);
        }

        public ICollection<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year)
        {
            ICollection<GetSchedulingsToCalendarResponse> schedulings = _schedulingRepository.GetSchedulingsToCalendar(month, year).ToList()
                ?? new List<GetSchedulingsToCalendarResponse>();

            var daysInMonth = GetDaysInMonth(month, year);

            if (schedulings.Count != daysInMonth.Count)
                AdjustDays(ref schedulings, daysInMonth);

            return schedulings;
        }

        public GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId)
        {
            var schedulingDetailsIds = _schedulingRepository.GetSchedulingDetailIds(schedulingId)
                ?? throw new InvalidOperationException("Nenhum agendamento encontrado");

            var customerDetails = _customerRepository.GetCustomerBasicInfo().ToList()
                ?? throw new InvalidOperationException("Nenhum cliente encontrado");

            var employeeDetails = _employeeRepository.GetEmployeeBasicInfo().ToList()
                ?? throw new InvalidOperationException("Nenhum funcionário encontrado");

            var procedureDetails = _procedureRepository.GetProcedureBasicInfo().ToList()
                 ?? throw new InvalidOperationException("Nenhum procedimento encontrado");

            return new GetSchedulingDetailResponse
            {
                CurrentCustomerId = schedulingDetailsIds.CurrentCustomerId,
                CurrentEmployeeId = schedulingDetailsIds.CurrentEmployeeId,
                CurrentProcedureId = schedulingDetailsIds.CurrentProcedureId,
                Customers = customerDetails,
                Employees = employeeDetails,
                Procedures = procedureDetails
            };
        }

        public async Task UpdateScheduling(int id, UpdateSchedulingRequest updateSchedulingRequest)
        {
            var scheduling = await _schedulingRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum agendamento encontrado");

            if (updateSchedulingRequest.CustomerId.HasValue)
            {
                var customer = await _customerRepository.GetById(updateSchedulingRequest.CustomerId.Value) ?? throw new InvalidOperationException("Nenhum cliente encontrado");
                scheduling.Customer = customer;
            }

            if (updateSchedulingRequest.EmployeeId.HasValue)
            {
                var employee = await _employeeRepository.GetById(updateSchedulingRequest.EmployeeId.Value) ?? throw new InvalidOperationException("Nenhum funcionário encontrado");
                scheduling.Employee = employee;
            }

            if (updateSchedulingRequest.ProcedureId.HasValue)
            {
                var procedure = await _procedureRepository.GetById(updateSchedulingRequest.ProcedureId.Value) ?? throw new InvalidOperationException("Nenhum procedimento encontrado");
                scheduling.Procedure = procedure;
            }

            if (updateSchedulingRequest.StartDate.HasValue)
                scheduling.StartDate = updateSchedulingRequest.StartDate.Value;

            scheduling.UpdatedAt = DateTime.Now;

            await _schedulingRepository.UpdateAsync(scheduling);
        }

        public async Task DeleteScheduling(int id) => await _schedulingRepository.Delete(id);

        private static void AdjustDays(ref ICollection<GetSchedulingsToCalendarResponse> schedulings, IEnumerable<int> daysInMonth)
        {
            var populatedDays = schedulings.Select(m => m.Day);

            foreach (var day in daysInMonth)
            {
                if (!populatedDays.Contains(day))
                    schedulings.Add(new GetSchedulingsToCalendarResponse
                    {
                        Day = day,
                    });
            }

            schedulings = schedulings.OrderBy(s => s.Day).ToList();
        }

        private static ICollection<int> GetDaysInMonth(int month, int year)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("O mês deve estar entre 1 e 12.", nameof(month));

            ICollection<int> daysInMonth = new List<int>();

            var daysQuantity = DateTime.DaysInMonth(year, month);

            for (var i = 1; i <= daysQuantity; i++)
            {
                daysInMonth.Add(i);
            }

            return daysInMonth;
        }
    }
}
