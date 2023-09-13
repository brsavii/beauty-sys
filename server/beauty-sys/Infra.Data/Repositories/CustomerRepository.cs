using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ConfigContext context) : base(context)
        {
        }
    }
}
