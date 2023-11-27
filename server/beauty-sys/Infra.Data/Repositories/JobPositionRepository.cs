using Domain.Interfaces.Repositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class JobPositionRepository : BaseRepository<JobPosition>, IJobPositionRepository
    {

        public JobPositionRepository(ConfigContext context) : base(context)
        {
        }
    }
}
