namespace Domain.Objects.Reponses
{
    public record ProcedureResponse
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
    }
}
