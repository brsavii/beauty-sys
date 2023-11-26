using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface ISchedulingAppService
    {
        Task UpdateScheduling(int id, UpdateSchedulingRequest updateSchedulingRequest);
    }
}
