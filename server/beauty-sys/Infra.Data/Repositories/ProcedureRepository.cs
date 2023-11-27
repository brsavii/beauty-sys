using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Reponses;
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

        public ICollection<ProcedureResponse> GetProcedures(int? id, string? name, int currentPage, int takeQuantity)
        {
            var query = GetAll(currentPage, takeQuantity);

            if (id.HasValue)
                query = query.Where(c => c.ProcedureId == id.Value);

            if (name != null)
                query = query.Where(c => c.Name.Contains(name));

            return _mapper.ProjectTo<ProcedureResponse>(query).ToList();
        }
    }
}
