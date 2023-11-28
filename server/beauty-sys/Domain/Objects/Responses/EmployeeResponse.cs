namespace Domain.Objects.Reponses
{
    public record EmployeeResponse
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Cpf { get; set; }
        public required string Office { get; set; }
    }
}
