using Domain.Models;

namespace Domain.Objects.Responses
{
    public record GetSchedulingsToCalendarResponse
    {
        public int Day { get; set; }
        public int? SchedulingId { get; set; }
        public DailySchedule? DailySchedules { get; set; }
    }

    public record DailySchedule
    {
        public required CustomerBasicInfo CustomerBasicInfo { get; set; }
        public required EmployeeBasicInfo EmployeeBasicInfo { get; set; }
        public required ProcedureBasicInfo ProcedureBasicInfo { get; set; }
        public virtual required SalonBasicInfo SalonBasicInfo { get; set; } // fazer esse
        public virtual required PaymentBasicInfo PaymentBasicInfo { get; set; } // fazer esse// fazer esse
    }
}
