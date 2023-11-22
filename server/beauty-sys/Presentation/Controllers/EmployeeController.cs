using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeAppService employeeAppService)
        {
            _employeeService = employeeService;
            _employeeAppService = employeeAppService;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(_employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _employeeService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            try
            {
                await _employeeService.CreateEmployee(createEmployeeRequest);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar novo funcionário: {ex.Message}");
            }
        }

        [HttpPatch("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            try
            {
                await _employeeAppService.UpdateEmployee(id, updateEmployeeRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar cliente: {ex.Message}");
            }
        }
    }
}
