using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
    [Route("Scheduling")]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingAppService _schedulingAppService;
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(ISchedulingAppService schedulingAppService, ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
            _schedulingAppService = schedulingAppService;
        }

        [HttpPost("SaveScheduling")]
        public async Task<IActionResult> SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            try
            {
                await _schedulingService.SaveScheduling(createSchedulingRequest);

                return Ok("Agendamento salvo com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateScheduling")]
        public async Task<IActionResult> UpdateScheduling(int id, UpdateSchedulingRequest updateSchedulingRequest)
        {
            try
            {
                await _schedulingAppService.UpdateScheduling(id, updateSchedulingRequest);

                return Ok("Agendamento atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteScheduling")]
        public async Task<IActionResult> DeleteScheduling(int id)
        {
            try
            {
                await _schedulingService.DeleteScheduling(id);

                return Ok("Agendamento deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSchedulingsToCalendar")]
        public IActionResult GetSchedulingsToCalendar(int month, int year, int? customerId, int? employeeId, int? procedureId, int? salonId)
        {
            try
            {
                return Ok(_schedulingService.GetSchedulingsToCalendar(month, year, customerId, employeeId, procedureId, salonId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSchedulingDetail")]
        public IActionResult GetSchedulingDetail(int schedulingId)
        {
            try
            {
                return Ok(_schedulingService.GetSchedulingDetail(schedulingId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
