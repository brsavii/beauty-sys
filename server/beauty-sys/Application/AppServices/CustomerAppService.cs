
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;
using Domain.Services;

namespace Application.AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {

            if (updateCustomerRequest.Name == null || updateCustomerRequest.Description == null || updateCustomerRequest.Phone == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            await _customerService.UpdateCustomer(id, updateCustomerRequest);
        }
    }
}
