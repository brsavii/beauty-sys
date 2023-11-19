using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class SchedulingRepository : BaseRepository<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(ConfigContext context) : base(context)
        {
        }
    }
}
