using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface ISalonService
    {
        Task DeleteSalon(int id);
        Task UpdateSalon(int id, UpdateSalonRequest updateSalonRequest);
        Task SaveSalon(CreateSalonRequest createSalonRequest);
    }
}
