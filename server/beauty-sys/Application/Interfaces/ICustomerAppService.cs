using Domain.Objects.Requests;

namespace Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest);
    }
}
