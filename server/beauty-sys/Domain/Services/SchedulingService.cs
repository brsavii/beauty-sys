using AutoMapper;
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
        private readonly ISalonRepository _salonRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public SchedulingService(ISchedulingRepository schedulingRepository, ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IProcedureRepository procedureRepository, ISalonRepository salonRepository, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _schedulingRepository = schedulingRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _procedureRepository = procedureRepository;
            _salonRepository = salonRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            if (await _schedulingRepository.HasAnyConflict(createSchedulingRequest))
                throw new InvalidOperationException("Existe um uncionário ou cliente em conflito com esses horários");

            var customer = await _customerRepository.GetById(createSchedulingRequest.CustomerId)
                ?? throw new InvalidOperationException("Nenhum cliente encontrado");

            var employee = await _employeeRepository.GetById(createSchedulingRequest.EmployeeId)
                ?? throw new InvalidOperationException("Nenhum funcionário encontrado");

            var procedure = await _procedureRepository.GetById(createSchedulingRequest.ProcedureId)
                ?? throw new InvalidOperationException("Nenhum procedimento encontrado");

            var salon = await _salonRepository.GetById(createSchedulingRequest.SalonId)
                ?? throw new InvalidOperationException("Nenhum salão encontrado");

            var payment = await _paymentRepository.GetById(createSchedulingRequest.PaymentId)
                ?? throw new InvalidOperationException("Nenhum pagamento encontrado");

            var scheduling = new Scheduling
            {
                StartDateTime = createSchedulingRequest.StartDateTime,
                Customer = customer,
                CustomerId = customer.CustomerId,
                Employee = employee,
                EmployeeId = employee.EmployeeId,
                Procedure = procedure,
                ProcedureId = procedure.ProcedureId,
                Salon = salon,
                Payment = payment,
                InsertedAt = DateTime.Now
            };

            await _schedulingRepository.SaveAsync(_mapper.Map<Scheduling>(createSchedulingRequest));
        }

        public ICollection<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year, int? customerId, int? employeeId, int? procedureId, int? salonId)
        {
            ICollection<GetSchedulingsToCalendarResponse> schedulings = _schedulingRepository.GetSchedulingsToCalendar(month, year, customerId, employeeId, procedureId, salonId).ToList()
                ?? new List<GetSchedulingsToCalendarResponse>();

            var daysInMonth = GetDaysInMonth(month, year);

            if (schedulings.Count != daysInMonth.Count)
                AdjustDays(ref schedulings, daysInMonth);

            return schedulings;
        }

        public GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId) => _schedulingRepository.GetSchedulingDetail(schedulingId)
                ?? throw new InvalidOperationException("Nenhum agendamento encontrado");

        public async Task UpdateScheduling(int id, UpdateSchedulingRequest updateSchedulingRequest)
        {
            var scheduling = await _schedulingRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum agendamento encontrado");

            var startDateTimeToCheck = updateSchedulingRequest.StartDateTime ?? scheduling.StartDateTime;
            var customerIdToCheck = updateSchedulingRequest.CustomerId ?? scheduling.CustomerId;
            var employeeIdToCheck = updateSchedulingRequest.EmployeeId ?? scheduling.EmployeeId;

            if (await _schedulingRepository.HasAnyConflict(startDateTimeToCheck, scheduling.SchedulingId, customerIdToCheck, employeeIdToCheck))
                throw new InvalidOperationException("Existe um uncionário ou cliente em conflito com esses horários");

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

            if (updateSchedulingRequest.SalonId.HasValue)
            {
                var salon = await _salonRepository.GetById(updateSchedulingRequest.SalonId.Value) ?? throw new InvalidOperationException("Nenhum salão encontrado");
                scheduling.Salon = salon;
            }

            if (updateSchedulingRequest.PaymentId.HasValue)
            {
                var payment = await _paymentRepository.GetById(updateSchedulingRequest.PaymentId.Value) ?? throw new InvalidOperationException("Nenhum pagamento encontrado");
                scheduling.Payment = payment;
            }

            if (updateSchedulingRequest.StartDateTime.HasValue)
                scheduling.StartDateTime = updateSchedulingRequest.StartDateTime.Value;

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
