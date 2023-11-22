using Domain.Models;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IQueryable<CustomerBasicInfo> GetCustomerBasicInfo();
    }
}
