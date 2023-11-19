using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Scheduling")]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpPost("SaveScheduling")]
        public async Task<IActionResult> SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            try
            {
                await _schedulingService.SaveScheduling(createSchedulingRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSchedulingsToCalendar")]
        public IActionResult GetSchedulingsToCalendar(int month, int year)
        {
            try
            {
                return Ok(_schedulingService.GetSchedulingsToCalendar(month, year));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
