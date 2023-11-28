namespace Domain.Objects.Reponses
{
    public record JobPositionResponse
    {
        public int JobPositionId { get; set; }
        public required string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
