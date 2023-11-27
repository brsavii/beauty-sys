namespace Domain.Objects.Requests
{
    public record CreateJobPositionRequest
    {
        public required string Name { get; set; }
        public required decimal Salary { get; set; }
    }
}
