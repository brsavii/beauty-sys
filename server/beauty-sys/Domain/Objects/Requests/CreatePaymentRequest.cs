
namespace Domain.Objects.Requests
{
    public record CreatePaymentRequest
    {
        public required string Name { get; set; }
        public decimal? Discount { get; set; }
    }
}
