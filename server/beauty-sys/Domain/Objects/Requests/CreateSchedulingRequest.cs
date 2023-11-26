
namespace Domain.Objects.Requests
{
    public record CreateSchedulingRequest
    {
        public DateTime StartDateTime { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ProcedureId { get; set; }
    }
}
