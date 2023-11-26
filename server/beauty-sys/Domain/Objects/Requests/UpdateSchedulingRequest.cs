
namespace Domain.Objects.Requests
{
    public record UpdateSchedulingRequest
    {
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProcedureId { get; set; }
    }
}
