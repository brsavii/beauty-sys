using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ConfigContext context) : base(context)
        {
        }
    }
}
