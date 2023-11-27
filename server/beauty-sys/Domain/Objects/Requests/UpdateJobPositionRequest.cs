namespace Domain.Objects.Requests
{
    public record UpdateJobPositionRequest
    {
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
    }
}
