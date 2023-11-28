using Domain.Models;

namespace Domain.Objects.Responses
{
    public record GetSchedulingsToCalendarResponse
    {
        public int Day { get; set; }
        public int? SchedulingId { get; set; }
        public DailySchedule? DailySchedule { get; set; }
    }

    public record DailySchedule
    {
        public required CustomerBasicInfo CustomerBasicInfo { get; set; }
        public required EmployeeBasicInfo EmployeeBasicInfo { get; set; }
        public required ProcedureBasicInfo ProcedureBasicInfo { get; set; }
        public virtual required SalonBasicInfo SalonBasicInfo { get; set; }
        public virtual required PaymentBasicInfo PaymentBasicInfo { get; set; } 
    }

    public record SalonBasicInfo
    {
        public int SalonId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
    }

    public record PaymentBasicInfo
    {
        public int PaymentId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
    }
}
