
using Application.Interfaces;
using Domain.Objects.Reponses;

namespace Application.AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        public Task<CustomerResponse> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
