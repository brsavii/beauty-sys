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
        public IActionResult GetJobPositions(int? id, string? name, int currentPage = 1, int takeQuantity = 10)
        {
            try
            {
                return Ok(_jobPositionService.GetJobPositions(id, name, currentPage, takeQuantity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateJobPosition/{Id}")]
        public async Task<IActionResult> UpdateJobPosition(int id, UpdateJobPositionRequest updateJobPositionRequest)
        {
            try
            {
                await _jobPositionService.UpdateJobPosition(id, updateJobPositionRequest);

                return Ok("Cargo atualizado com sucesso");
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

                return Ok("Cargo salvo com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteJobPosition/{Id}")]
        public async Task<IActionResult> DeleteJobPosition(int id)
        {
            try
            {
                await _jobPositionService.DeleteJobPosition(id);

                return Ok("Cargo deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
