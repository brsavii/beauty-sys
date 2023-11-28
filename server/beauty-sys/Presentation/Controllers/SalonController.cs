using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
    [Route("Salon")]
    public class SalonController : ControllerBase
    {
        private readonly ISalonService _salonService;

        public SalonController(ISalonService salonService)
        {
            _salonService = salonService;
        }

        [HttpPatch("UpdateSalon")]
        public async Task<IActionResult> UpdateSalon(UpdateSalonRequest updateSalonRequest)
        {
            try
            {
                await _salonService.UpdateSalon(updateSalonRequest);

                return Ok("Salão atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveSalon")]
        public async Task<IActionResult> SaveSalon(CreateSalonRequest createSalonRequest)
        {
            try
            {
                await _salonService.SaveSalon(createSalonRequest);

                return Ok("Salão salvo com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSalon/{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            try
            {
                await _salonService.DeleteSalon(id);

                return Ok("Salão deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
