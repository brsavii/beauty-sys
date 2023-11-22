using Domain.Models;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface ISchedulingRepository : IBaseRepository<Scheduling>
    {
        SchedulingDetailsIds GetSchedulingDetailIds(int schedulingId);
        IQueryable<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year);
    }
}
