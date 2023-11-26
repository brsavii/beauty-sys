namespace Domain.Objects.Requests
{
    public record CreateCustomerRequest
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Description { get; set; }
    }
}
