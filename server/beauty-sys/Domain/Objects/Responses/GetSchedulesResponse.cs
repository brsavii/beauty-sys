namespace Domain.Objects.Responses
{
    public record GetSchedulingsResponse
    {
        public required ICollection<Day> Days { get; set; }
    }

    public record Day
    {
        public CustomerBaseInfo? CustomerInfo { get; set; }
    }

    public record CustomerBaseInfo
    {
        public required string CustomerId { get; set; }
        public required string CustomerName { get; set; }
    }
}
