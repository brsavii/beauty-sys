
using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;

namespace Application.AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            if (createCustomerRequest.Phone.Length != 11)
                throw new InvalidOperationException("Telefone inválido");

            await _customerService.CreateCustomer(createCustomerRequest);
        }

        public async Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            if (updateCustomerRequest.Name == null && updateCustomerRequest.Description == null && updateCustomerRequest.Phone == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            await _customerService.UpdateCustomer(id, updateCustomerRequest);
        }
    }
}
