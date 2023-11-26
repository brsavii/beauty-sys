using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface IProcedureAppService
    {
        Task UpdateProcedure(int id, UpdateProcedureRequest updateProcedureRequest);
    }
}
