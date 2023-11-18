using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("User")]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpPost("SaveScheduling")]
        public IActionResult SaveScheduling(CreateSchedulingRequest createSchedulingRequest)
        {
            try
            {
                return Ok(_schedulingService.SaveScheduling(createSchedulingRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSchedulings")]
        public IActionResult GetSchedulings(int month, int year)
        {
            try
            {
                return Ok(_schedulingService.GetSchedulings(month));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
