using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        List<CustomerResponse> GetCustomers();
        Task<CustomerResponse> GetById(int id);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest);
        Task CreateCustomer(CreateCustomerRequest createCustomerRequest);
    }
}
