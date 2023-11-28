using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IJobPositionService
    {
        Task DeleteJobPosition(int id);
        ICollection<JobPositionResponse> GetJobPositions(int? id, string? name, int currentPage, int takeQuantity);
        Task SaveJobPosition(CreateJobPositionRequest createJobPositionRequest);
        Task UpdateJobPosition(int id, UpdateJobPositionRequest updateJobPositionRequest);
    }
}
