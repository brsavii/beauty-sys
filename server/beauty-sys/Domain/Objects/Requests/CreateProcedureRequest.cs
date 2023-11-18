namespace Domain.Objects.Requests
{
    public class CreateProcedureRequest
    {
        public required string Name { get; set; }
        public required decimal Value { get; set; }
    }
}
