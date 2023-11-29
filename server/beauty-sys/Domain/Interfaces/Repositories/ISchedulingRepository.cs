using Domain.Models;
using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface ISchedulingRepository : IBaseRepository<Scheduling>
    {
        GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId);
        ICollection<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year, int? customerId, int? employeeId, int? procedureId, int? salonId);
        Task<bool> HasAnyConflict(CreateSchedulingRequest createSchedulingRequest);
        Task<bool> HasAnyConflict(DateTime startDateTime, int schedulingId, int customerId, int employeeId);
    }
}
