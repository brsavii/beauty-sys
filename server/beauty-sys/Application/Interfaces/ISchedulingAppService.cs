using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface ISchedulingAppService
    {
        Task UpdateScheduling(UpdateSchedulingRequest updateSchedulingRequest);
    }
}
