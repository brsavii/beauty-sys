namespace Domain.Objects.Requests
{
    public class UpdateProcedureRequest
    {
        public string? Name { get; set; }
        public decimal? Value { get; set; }
        public int? ProcedureTime { get; set; }
    }
}
