
namespace Domain.Objects.Requests
{
    public record UpdateSchedulingRequest
    {
        public int SchedulingId { get; set; }

        public DateTime? StartDateTime { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProcedureId { get; set; }
        public int? SalonId { get; set; }
        public int? PaymentId { get; set; }
    }
}
