
using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;

namespace Application.AppServices
{
    public class ProcedureAppService : IProcedureAppService
    {
        private readonly IProcedureService _procedureService;

        public ProcedureAppService(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        public async Task UpdateProcedure(UpdateProcedureRequest updateProcedureRequest)
        {
            if (updateProcedureRequest.Name == null && updateProcedureRequest.Value == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            await _procedureService.UpdateProcedure(updateProcedureRequest);
        }
    }
}
