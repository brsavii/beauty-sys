using Domain.Interfaces.Services;
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


        //criar metodo pra salvar 

        [HttpGet("GetSchedules")]
        public IActionResult GetSchedules(int month, int year)
        {
            try
            {
                return Ok(_schedulingService.GetSchedules(month));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
