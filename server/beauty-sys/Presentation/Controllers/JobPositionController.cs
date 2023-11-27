using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
    [Route("JobPosition")]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;

        public JobPositionController(IJobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }

        [HttpGet("GetJobPositions")]
        public IActionResult GetJobPositions(int currentPage = 1, int takeQuantity = 10)
        {
            try
            {
                return Ok(_jobPositionService.GetJobPositions(currentPage, takeQuantity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateJobPosition")]
        public async Task<IActionResult> UpdateJobPosition(int id, UpdateJobPositionRequest updateJobPositionRequest)
        {
            try
            {
                await _jobPositionService.UpdateJobPosition(id, updateJobPositionRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveJobPosition")]
        public async Task<IActionResult> SaveJobPosition(CreateJobPositionRequest CreateJobPositionRequest)
        {
            try
            {
                await _jobPositionService.SaveJobPosition(CreateJobPositionRequest);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
