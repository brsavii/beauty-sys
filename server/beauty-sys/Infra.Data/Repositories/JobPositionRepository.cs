using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Reponses;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class JobPositionRepository : BaseRepository<JobPosition>, IJobPositionRepository
    {
        private readonly IMapper _mapper;

        public JobPositionRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        ICollection<JobPositionResponse> IJobPositionRepository.GetJobPositions(int? id, string? name, int currentPage, int takeQuantity)
        {
            var query = GetAll(currentPage, takeQuantity);

            if (id.HasValue)
                query = query.Where(c => c.JobPositionId == id.Value);

            if (name != null)
                query = query.Where(c => c.Name.Contains(name));

            return _mapper.ProjectTo<JobPositionResponse>(query).ToList();
        }
    }
}
