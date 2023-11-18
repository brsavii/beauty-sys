namespace Domain.Objects.Requests
{
    public record CreateCustomerRequest
    {
        public required string Name { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
    }
}
