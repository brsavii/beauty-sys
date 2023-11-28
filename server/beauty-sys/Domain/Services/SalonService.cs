using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _salonRepository;
        private readonly IMapper _mapper;

        public SalonService(ISalonRepository salonRepository, IMapper mapper)
        {
            _salonRepository = salonRepository;
            _mapper = mapper;
        }

        public async Task SaveSalon(CreateSalonRequest createSalonRequest) => await _salonRepository.SaveAsync(_mapper.Map<Salon>(createSalonRequest));

        public async Task UpdateSalon(UpdateSalonRequest updateSalonRequest)
        {
            if (updateSalonRequest.Name == null && updateSalonRequest.Location == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            var salon = await _salonRepository.GetById(updateSalonRequest.SalonId) ?? throw new InvalidOperationException("Nenhum salão encontrado");

            if (updateSalonRequest.Name != null)
                salon.Name = updateSalonRequest.Name;

            if (updateSalonRequest.Location != null)
                salon.Location = updateSalonRequest.Location;

            salon.UpdatedAt = DateTime.Now;

            await _salonRepository.UpdateAsync(salon);
        }

        public async Task DeleteSalon(int id) => await _salonRepository.Delete(id);
    }
}
