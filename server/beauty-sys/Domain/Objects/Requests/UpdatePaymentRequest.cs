
namespace Domain.Objects.Requests
{
    public record UpdatePaymentRequest
    {
        public string? Name { get; set; }
        public decimal? Discount { get; set; }
    }
}
