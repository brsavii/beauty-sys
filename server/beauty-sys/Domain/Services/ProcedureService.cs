using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
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

        public async Task DeleteProcedure(int id) => await _procedureRepository.Delete(id);

        public ICollection<ProcedureResponse> GetProcedures(int currentPage, int takeQuantity)
        {
            var customers = _procedureRepository.GetAll(currentPage, takeQuantity);

            if (!customers.Any())
                throw new InvalidOperationException("Nenhuma operação encontrado");

            return _mapper.ProjectTo<ProcedureResponse>(customers).ToList();
        }

        public async Task SaveProcedure(CreateProcedureRequest createProcedureRequest) => await _procedureRepository.SaveAsync(_mapper.Map<Procedure>(createProcedureRequest));

        public async Task UpdateProcedure(int id, UpdateProcedureRequest updateProcedureRequest)
        {
            var procedure = await _procedureRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum procedimento encontrado");

            if (updateProcedureRequest.Name != null)
                procedure.Name = updateProcedureRequest.Name;

            if (updateProcedureRequest.Value != null)
                procedure.Value = updateProcedureRequest.Value.Value;

            procedure.UpdatedAt = DateTime.Now;

            await _procedureRepository.UpdateAsync(procedure);
        }
    }
}
