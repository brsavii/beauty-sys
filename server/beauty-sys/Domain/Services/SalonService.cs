using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepository _salonRepository;

        public SalonService(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        public async Task SaveSalon(CreateSalonRequest createSalonRequest)
        {
            var salon = new Salon
            {
                Name = createSalonRequest.Name,
                Location = createSalonRequest.Location,
                InsertedAt = DateTime.Now
            };

            await _salonRepository.SaveAsync(salon);
        }

        public async Task UpdateSalon(int id, UpdateSalonRequest updateSalonRequest)
        {
            if (updateSalonRequest.Name == null && updateSalonRequest.Location == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            var salon = await _salonRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum salão encontrado");

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
