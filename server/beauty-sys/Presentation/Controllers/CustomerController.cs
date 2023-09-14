using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils.Base;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<JsonResult> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomers();

                return ReponseBase.DefaultResponse(true, objectData: customers);
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
                var customers = await _customerService.GetById(id);

                return ReponseBase.DefaultResponse(true, objectData: customers);
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, message: ex.Message);
            }
        }

        [HttpDelete("DeleteCustomers")]
        public async Task<JsonResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);

                return ReponseBase.DefaultResponse(true, "Cliente deletado com sucesso");
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, $"Erro ao deletar cliente: {ex.Message}");
            }
        }
    }
}
