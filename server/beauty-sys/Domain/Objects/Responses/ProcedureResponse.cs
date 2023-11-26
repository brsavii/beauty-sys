namespace Domain.Objects.Reponses
{
    public record ProcedureResponse
    {
        public required string Name { get; set; }
        public decimal Value { get; set; }
    }
}
