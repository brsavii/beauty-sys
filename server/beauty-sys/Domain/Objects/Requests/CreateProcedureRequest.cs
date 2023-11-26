namespace Domain.Objects.Requests
{
    public class CreateProcedureRequest
    {
        public required string Name { get; set; }
        public int ProcedureTime { get; set; }
        public decimal Value { get; set; }
    }
}
