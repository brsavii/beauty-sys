using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task SavePayment(CreatePaymentRequest createPaymentRequest)
        {
            if (createPaymentRequest.Discount.HasValue && createPaymentRequest.Discount.Value <= 0)
                throw new InvalidOperationException("O desconto não pode ser igual ou menor que zero");

            await _paymentRepository.SaveAsync(_mapper.Map<Payment>(createPaymentRequest));
        }

        public async Task UpdatePayment(UpdatePaymentRequest updatePaymentRequest)
        {
            if (updatePaymentRequest.Name == null)
                throw new InvalidOperationException("Nenhuma modificação foi realizada!");

            if (updatePaymentRequest.Discount.HasValue && updatePaymentRequest.Discount.Value <= 0)
                throw new InvalidOperationException("O desconto não pode ser igual ou menor que zero");

            var payment = await _paymentRepository.GetById(updatePaymentRequest.PaymentId) ?? throw new InvalidOperationException("Nenhum pagamento encontrado");

            if (updatePaymentRequest.Name != null)
                payment.Name = updatePaymentRequest.Name;

            if (updatePaymentRequest.Discount != null)
                payment.Discount = updatePaymentRequest.Discount;

            payment.UpdatedAt = DateTime.Now;

            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task DeletePayment(int id) => await _paymentRepository.Delete(id);
    }
}
