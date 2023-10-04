using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;
using Presentation.Utils.Base;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerService customerService, ICustomerAppService customerAppService)
        {
            _customerService = customerService;
            _customerAppService = customerAppService;
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

        [HttpDelete("DeleteCustomer")]
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

        [HttpPatch("UpdateCustomer")]
        public async Task<JsonResult> UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            try
            {
                await _customerAppService.UpdateCustomer(id, updateCustomerRequest);

                return ReponseBase.DefaultResponse(true, "Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, $"Erro ao atualizar: {ex.Message}");
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<JsonResult> SaveCustomer([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            try
            {
                await _customerService.CreateCustomer(createCustomerRequest);
                return ReponseBase.DefaultResponse(true, "Cliente cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                return ReponseBase.DefaultResponse(false, $"Erro ao cadastrar novo cliente: {ex.Message}");
            }
        }
    }
}
