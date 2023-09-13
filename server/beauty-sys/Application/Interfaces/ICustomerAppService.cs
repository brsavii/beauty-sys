using Domain.Objects.Reponses;

namespace Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<CustomerResponse> GetCustomers();
    }
}
