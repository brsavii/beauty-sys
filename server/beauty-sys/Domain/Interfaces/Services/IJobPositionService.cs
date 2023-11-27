using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IJobPositionService
    {
        ICollection<JobPositionResponse> GetJobPositions(int currentPage, int takeQuantity);
        Task SaveJobPosition(CreateJobPositionRequest createJobPositionRequest);
        Task UpdateJobPosition(int id, UpdateJobPositionRequest updateJobPositionRequest);
    }
}
