using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;

        public ProcedureService(IProcedureRepository procedureRepository, IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        public async Task SaveProcedure(CreateProcedureRequest createProcedureRequest) => await _procedureRepository.SaveAsync(_mapper.Map<Procedure>(createProcedureRequest));
    }
}
