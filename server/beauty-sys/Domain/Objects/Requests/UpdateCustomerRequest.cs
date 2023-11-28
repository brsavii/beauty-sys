namespace Domain.Objects.Requests
{
    public record UpdateCustomerRequest
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
    }
}
