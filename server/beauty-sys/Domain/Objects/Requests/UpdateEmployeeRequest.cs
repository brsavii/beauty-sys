namespace Domain.Objects.Requests
{
    public class UpdateEmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Office { get; set; }
        public int? JobPositionId { get; set; }
    }
}
