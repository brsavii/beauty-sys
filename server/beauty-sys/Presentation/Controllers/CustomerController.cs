using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetCustomers(int currentPage, int takeQuantity = 10)
        {
            try
            {
                return Ok(_customerService.GetCustomers(currentPage, takeQuantity));
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
                await _customerService.DeleteCustomer(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            try
            {
                await _customerAppService.UpdateCustomer(id, updateCustomerRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            try
            {
                await _customerService.CreateCustomer(createCustomerRequest);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
