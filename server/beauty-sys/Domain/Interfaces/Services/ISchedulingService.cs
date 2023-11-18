using Domain.Objects.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISchedulingService
    {
        GetSchedulesResponse GetSchedules(int month);
    }
}
