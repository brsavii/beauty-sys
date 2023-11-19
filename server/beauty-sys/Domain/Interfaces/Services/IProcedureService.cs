using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IProcedureService
    {
        Task SaveProcedure(CreateProcedureRequest createProcedureRequest);
    }
}
