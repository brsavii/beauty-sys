namespace Domain.Objects.Requests
{
    public class UpdateEmployeeRequest
    {
        public string? Name { get; set; }
        public string? Office { get; set; }
        public int? JobPositionId { get; set; }
    }
}
