using Domain.Objects.Reponses;

namespace Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetCustomers();
        Task<CustomerResponse> GetById(int id);
        Task DeleteCustomer(int id);
    }
}
