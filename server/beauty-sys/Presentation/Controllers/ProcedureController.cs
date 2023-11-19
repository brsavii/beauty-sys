using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("User")]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpPost("SaveProcedure")]
        public async Task<IActionResult> SaveProcedure(CreateProcedureRequest createProcedureRequest)
        {
            try
            {
                await _procedureService.SaveProcedure(createProcedureRequest);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar novo procedimento: {ex.Message}");
            }
        }
    }
}
