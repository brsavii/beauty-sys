using Domain.Models;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface ISchedulingRepository : IBaseRepository<Scheduling>
    {
        IQueryable<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year);
    }
}
