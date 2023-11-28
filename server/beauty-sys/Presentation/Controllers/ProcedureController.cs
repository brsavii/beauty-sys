using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
    [Route("User")]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureAppService _procedureAppService;
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureAppService procedureAppService, IProcedureService procedureService)
        {
            _procedureAppService = procedureAppService;
            _procedureService = procedureService;
        }

        [HttpGet("GetProcedures")]
        public IActionResult GetProcedures(int? id, string? name, int currentPage = 1, int takeQuantity = 10)
        {
            try
            {
                return Ok(_procedureService.GetProcedures(id, name, currentPage, takeQuantity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveProcedure")]
        public async Task<IActionResult> SaveProcedure(CreateProcedureRequest createProcedureRequest)
        {
            try
            {
                await _procedureService.SaveProcedure(createProcedureRequest);

                return Ok("Procedimento salvo com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar novo procedimento: {ex.Message}");
            }
        }

        [HttpPatch("UpdateProcedure/{Id}")]
        public async Task<IActionResult> UpdateProcedure(int id, UpdateProcedureRequest updateProcedureRequest)
        {
            try
            {
                await _procedureAppService.UpdateProcedure(id, updateProcedureRequest);

                return Ok("Procedimento atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProcedure/{Id}")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            try
            {
                await _procedureService.DeleteProcedure(id);

                return Ok("Procedimento deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
