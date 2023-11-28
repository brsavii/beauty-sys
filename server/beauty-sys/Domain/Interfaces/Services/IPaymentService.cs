using Domain.Objects.Requests;

namespace Domain.Interfaces.Services
{
    public interface IPaymentService
    {
        Task DeletePayment(int id);
        Task UpdatePayment(UpdatePaymentRequest updatePaymentRequest);
        Task SavePayment(CreatePaymentRequest createPaymentRequest);
    }
}
