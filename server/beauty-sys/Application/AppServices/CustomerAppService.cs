
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
            if (!IsValidPhoneNumber(createCustomerRequest.Phone))
                throw new InvalidOperationException("Telefone inválido");

            await _customerService.CreateCustomer(createCustomerRequest);
        }

        public async Task UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
        {
            if (updateCustomerRequest.Name == null && updateCustomerRequest.Description == null && updateCustomerRequest.Phone == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            if (updateCustomerRequest.Phone != null && !IsValidPhoneNumber(updateCustomerRequest.Phone))
                throw new InvalidOperationException("Telefone inválido");

            await _customerService.UpdateCustomer(updateCustomerRequest);
        }

        private static bool IsValidPhoneNumber(string phoneNumber) => phoneNumber.Length == 11;
    }
}
