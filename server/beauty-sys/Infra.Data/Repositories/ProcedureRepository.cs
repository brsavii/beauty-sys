using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Responses;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ProcedureRepository : BaseRepository<Procedure>, IProcedureRepository
    {
        private readonly IMapper _mapper;

        public ProcedureRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<ProcedureBasicInfo> GetProcedureBasicInfo() => _mapper.ProjectTo<ProcedureBasicInfo>(_typedContext);
    }
}
