namespace Domain.Objects.Requests
{
    public record UpdateJobPositionRequest
    {
        public int JobPositionId { get; set; }
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
    }
}
