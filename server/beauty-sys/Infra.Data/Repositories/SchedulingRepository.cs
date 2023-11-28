using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Requests;
using Domain.Objects.Responses;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class SchedulingRepository : BaseRepository<Scheduling>, ISchedulingRepository
    {
        private readonly IMapper _mapper;

        public SchedulingRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year, int? customerId, int? employeeId, int? procedureId, int? salonId)
        {
            var query = _typedContext
                .AsNoTracking()
                .Include(s => s.Customer)
                .Where(s => s.StartDateTime.Month == month && s.StartDateTime.Year == year);

            if (customerId.HasValue)
                query = query.Where(s => s.CustomerId == customerId.Value);

            if (employeeId.HasValue)
                query = query.Where(s => s.CustomerId == employeeId.Value);

            if (procedureId.HasValue)
                query = query.Where(s => s.CustomerId == procedureId.Value);

            if (salonId.HasValue)
                query = query.Where(s => s.CustomerId == salonId.Value);

            return _mapper.ProjectTo<GetSchedulingsToCalendarResponse>(query);
        }

        public GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId)
        {
            var scheduling = _typedContext
                .AsNoTracking()
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.Procedure)
                .Include(s => s.Payment)
                .Include(s => s.Salon)
                .Where(s => s.SchedulingId == schedulingId)
                ?? throw new InvalidOperationException("Nenhum agendamento encontrado");

            return _mapper.Map<GetSchedulingDetailResponse>(scheduling);
        }

        public async Task<bool> HasAnyConflict(CreateSchedulingRequest createSchedulingRequest)
        {
            return await _typedContext
                .AsNoTracking()
                .Include(s => s.Procedure)
                .AnyAsync(s => (s.EmployeeId == createSchedulingRequest.EmployeeId || s.CustomerId == createSchedulingRequest.CustomerId) &&
                    (s.StartDateTime.AddMinutes(s.Procedure.ProcedureTime * -1) <= createSchedulingRequest.StartDateTime &&
                    s.StartDateTime.AddMinutes(s.Procedure.ProcedureTime) >= createSchedulingRequest.StartDateTime));
        }

        public async Task<bool> HasAnyConflict(DateTime startDateTime, int schedulingId, int customerId, int employeeId)
        {
            return await _typedContext
                .AsNoTracking()
                .Where(s => s.SchedulingId != schedulingId)
                .Include(s => s.Procedure)
                .AnyAsync(s => (s.EmployeeId == employeeId || s.CustomerId == customerId) &&
                    (s.StartDateTime.AddMinutes(s.Procedure.ProcedureTime * -1) <= startDateTime &&
                    s.StartDateTime.AddMinutes(s.Procedure.ProcedureTime) >= startDateTime));
        }
    }
}
