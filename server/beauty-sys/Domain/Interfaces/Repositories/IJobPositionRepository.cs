using Domain.Models;
using Domain.Objects.Reponses;

namespace Domain.Interfaces.Repositories
{
    public interface IJobPositionRepository : IBaseRepository<JobPosition>
    {
        ICollection<JobPositionResponse> GetJobPositions(int? id, string? name, int currentPage, int takeQuantity);
    }
}
