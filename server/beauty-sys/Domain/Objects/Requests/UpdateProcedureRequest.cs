namespace Domain.Objects.Requests
{
    public class UpdateProcedureRequest
    {
        public required string Name { get; set; }
        public decimal? Value { get; set; }
    }
}
