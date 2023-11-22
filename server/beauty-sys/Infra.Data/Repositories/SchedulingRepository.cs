using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
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

        public IQueryable<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year)
        {
            return _mapper.ProjectTo<GetSchedulingsToCalendarResponse>(_typedContext
                .AsNoTracking()
                .Include(s => s.Customer)
                .Where(s => s.StartDate.Month == month && s.StartDate.Year == year));
        }

        public SchedulingDetailsIds GetSchedulingDetailIds(int schedulingId)
        {
            return _mapper.Map<SchedulingDetailsIds>(_typedContext
                .AsNoTracking()
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.Procedure)
                .Where(s => s.SchedulingId == schedulingId));
        }
    }
}
