using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController, Authorize]
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
        public IActionResult GetEmployees(int? id, string? name, int currentPage = 1, int takeQuantity = 10)
        {
            try
            {
                return Ok(_employeeService.GetEmployees(id, name, currentPage, takeQuantity));
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

                return Ok("Funcionário salvo com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
        {
            try
            {
                await _employeeAppService.UpdateEmployee(updateEmployeeRequest);

                return Ok("Funcionário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _employeeService.DeleteCustomer(id);

                return Ok("Funcionário deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
