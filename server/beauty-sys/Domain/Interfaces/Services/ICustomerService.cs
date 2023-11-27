using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        ICollection<CustomerResponse> GetCustomers(int currentPage, int takeQuantity, int? id, string? name);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest);
        Task CreateCustomer(CreateCustomerRequest createCustomerRequest);
    }
}
