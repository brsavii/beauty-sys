
using Application.Interfaces;
using Domain.Interfaces.Services;
using Domain.Objects.Requests;

namespace Application.AppServices
{
    public class SchedulingAppService : ISchedulingAppService
    {
        private readonly ISchedulingService _schedulingService;

        public SchedulingAppService(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        public async Task UpdateScheduling(int id, UpdateSchedulingRequest updateSchedulingRequest)
        {
            if (updateSchedulingRequest.CustomerId == null && updateSchedulingRequest.ProcedureId == null && updateSchedulingRequest.EmployeeId == null && updateSchedulingRequest.SalonId == null && updateSchedulingRequest.PaymentId == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            await _schedulingService.UpdateScheduling(id, updateSchedulingRequest);
        }
    }
}
