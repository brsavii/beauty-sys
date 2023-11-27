using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface IProcedureRepository : IBaseRepository<Procedure>
    {
        IQueryable<ProcedureBasicInfo> GetProcedureBasicInfo();
        ICollection<ProcedureResponse> GetProcedures(int? id, string? name, int currentPage, int takeQuantity);
    }
}
