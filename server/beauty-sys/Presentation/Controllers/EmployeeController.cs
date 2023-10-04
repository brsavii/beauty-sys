using Application.AppServices;
using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils.Base;

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
        public async Task<JsonResult> GetEmployees()    
        {
            try
            {
                var employees = await _employeeService.GetEmployees();

                return ReponseBase.DefaultResponse(true, objectData: employees);
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, message: ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<JsonResult> GetById(int id)
        {
            try
            {
                var employee = await _employeeService.GetById(id);

                return ReponseBase.DefaultResponse(true, objectData: employee);
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, message: ex.Message);
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<JsonResult> SaveEmployee([FromBody] CreateEmployeeRequest createEmployeeRequest)
        {
            try
            {
                await _employeeService.CreateEmployee(createEmployeeRequest);
                return ReponseBase.DefaultResponse(true, "Funcionário cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, $"Erro ao cadastrar novo funcionário: {ex.Message}");
            }
        }

        [HttpPatch("UpdateEmployee")]
        public async Task<JsonResult> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            try
            {
                await _employeeAppService.UpdateEmployee(id, updateEmployeeRequest);

                return ReponseBase.DefaultResponse(true, "Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, $"Erro ao atualizar cliente: {ex.Message}");
            }
        }
    }
}
