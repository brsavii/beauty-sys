using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISchedulingService
    {
        Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest);
        ICollection<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year, int? customerId, int? employeeId, int? procedureId, int? salonId);
        GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId);
        Task UpdateScheduling(UpdateSchedulingRequest updateSchedulingRequest);
        Task DeleteScheduling(int id);
    }
}
