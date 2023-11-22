using Domain.Models;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface IProcedureRepository : IBaseRepository<Procedure>
    {
        IQueryable<ProcedureBasicInfo> GetProcedureBasicInfo();
    }
}
