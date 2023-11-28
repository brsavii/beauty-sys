using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class JobPositionService : IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        private readonly IMapper _mapper;

        public JobPositionService(IJobPositionRepository jobPositionRepository, IMapper mapper)
        {
            _jobPositionRepository = jobPositionRepository;
            _mapper = mapper;
        }

        public ICollection<JobPositionResponse> GetJobPositions(int? id, string? name, int currentPage, int takeQuantity)
        {
            var jobPositions = _jobPositionRepository.GetJobPositions(id, name, currentPage, takeQuantity);

            if (!jobPositions.Any())
                throw new InvalidOperationException("Nenhum cargo encontrado");

            return jobPositions;
        }

        public async Task SaveJobPosition(CreateJobPositionRequest createJobPositionRequest)
        {
            if (createJobPositionRequest.Salary <= 0)
                throw new InvalidOperationException("O salário não pode ser igual ou menor que zero");

            await _jobPositionRepository.SaveAsync(_mapper.Map<JobPosition>(createJobPositionRequest));

        }
        public async Task UpdateJobPosition(UpdateJobPositionRequest updateJobPositionRequest)
        {
            if (updateJobPositionRequest.Name == null && updateJobPositionRequest.Salary == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            if (updateJobPositionRequest.Salary <= 0)
                throw new InvalidOperationException("O salário não pode ser igual ou menor que zero");

            var jobPosition = await _jobPositionRepository.GetById(updateJobPositionRequest.JobPositionId) ?? throw new InvalidOperationException("Nenhum cargo encontrado");

            if (updateJobPositionRequest.Name != null)
                jobPosition.Name = updateJobPositionRequest.Name;

            if (updateJobPositionRequest.Salary != null)
                jobPosition.Salary = updateJobPositionRequest.Salary.Value;

            jobPosition.UpdatedAt = DateTime.Now;

            await _jobPositionRepository.UpdateAsync(jobPosition);
        }

        public async Task DeleteJobPosition(int id) => await _jobPositionRepository.Delete(id);
    }
}
