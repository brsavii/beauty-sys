using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils.Base;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
    }
}
