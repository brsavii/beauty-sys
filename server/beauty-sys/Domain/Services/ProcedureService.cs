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

        public ICollection<ProcedureResponse> GetProcedures(int? id, string? name, int currentPage, int takeQuantity)
        {
            var procedures = _procedureRepository.GetProcedures(id, name, currentPage, takeQuantity);

            if (!procedures.Any())
                throw new InvalidOperationException("Nenhum procedimento encontrado");

            return procedures;
        }

        public async Task SaveProcedure(CreateProcedureRequest createProcedureRequest) => await _procedureRepository.SaveAsync(_mapper.Map<Procedure>(createProcedureRequest));

        public async Task UpdateProcedure(UpdateProcedureRequest updateProcedureRequest)
        {
            var procedure = await _procedureRepository.GetById(updateProcedureRequest.ProcedureId) ?? throw new InvalidOperationException("Nenhum procedimento encontrado");

            if (updateProcedureRequest.Name != null)
                procedure.Name = updateProcedureRequest.Name;

            if (updateProcedureRequest.Value != null)
                procedure.Value = updateProcedureRequest.Value.Value;

            if (updateProcedureRequest.ProcedureTime != null)
                procedure.ProcedureTime = updateProcedureRequest.ProcedureTime.Value;

            procedure.UpdatedAt = DateTime.Now;

            await _procedureRepository.UpdateAsync(procedure);
        }
    }
}
