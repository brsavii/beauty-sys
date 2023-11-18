using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Services
{
    public interface ISchedulingService
    {
        Task SaveScheduling(CreateSchedulingRequest createSchedulingRequest);
        GetSchedulingsResponse GetSchedulings(int month);
    }
}
