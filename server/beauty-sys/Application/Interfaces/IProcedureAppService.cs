using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface IProcedureAppService
    {
        Task UpdateProcedure(UpdateProcedureRequest updateProcedureRequest);
    }
}
