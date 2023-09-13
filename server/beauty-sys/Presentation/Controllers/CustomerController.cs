]using Application.AppServices;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [Route("GetCustomers")]
        public JsonResult GetCustomers()
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
