namespace Domain.Objects.Reponses
{
    public record JobPositionResponse
    {
        public required string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
