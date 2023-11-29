namespace Domain.Objects.Responses
{
    public record GetSchedulingsToCalendarResponse
    {
        public int Day { get; set; }
        public int? SchedulingId { get; set; }
        public CustomerBasicInfo? CustomerBasicInfo { get; set; }
        public EmployeeBasicInfo? EmployeeBasicInfo { get; set; }
        public ProcedureBasicInfo? ProcedureBasicInfo { get; set; }
        public SalonBasicInfo? SalonBasicInfo { get; set; }
        public PaymentBasicInfo? PaymentBasicInfo { get; set; }
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
