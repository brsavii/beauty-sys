using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task CreateCustomer(CreateCustomerRequest createCustomerRequest);
        Task UpdateCustomer(UpdateCustomerRequest updateCustomerRequest);
    }
}
