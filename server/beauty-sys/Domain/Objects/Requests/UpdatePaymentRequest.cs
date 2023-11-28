
namespace Domain.Objects.Requests
{
    public record UpdatePaymentRequest
    {
        public int PaymentId { get; set; }

        public string? Name { get; set; }
        public decimal? Discount { get; set; }
    }
}
