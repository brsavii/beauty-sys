using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Responses;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IQueryable<CustomerBasicInfo> GetCustomerBasicInfo();
        ICollection<CustomerResponse> GetCustomers(int currentPage, int takeQuantity, int? id, string? name);
    }
}
