using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISchedulingService
    {
        Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest);
        ICollection<GetSchedulingsToCalendarResponse> GetSchedulingsToCalendar(int month, int year);
        GetSchedulingDetailResponse GetSchedulingDetail(int schedulingId);
    }
}
