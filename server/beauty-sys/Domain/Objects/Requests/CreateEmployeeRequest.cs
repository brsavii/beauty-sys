namespace Domain.Objects.Requests
{
    public record CreateEmployeeRequest
    {
        public required string Name { get; set; }
        public required string Office { get; set; }
        public required string Cpf { get; set; }
        public int JobPositionId { get; set; }
    }
}
