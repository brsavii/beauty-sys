namespace Domain.Objects.Responses
{
    public record GetSchedulingsToCalendarResponse
    {
        public int Day { get; set; }
        public int? SchedulingId { get; set; }
        public ICollection<SchedulingDetail>? SchedulingDetails { get; set; }   
    }

    public record SchedulingDetail
    {
        public DateTime StartDateTime { get; set; }
        public decimal TotalValue { get; set; }
        public required CustomerBasicInfo CustomerBasicInfo { get; set; }
        public required EmployeeBasicInfo EmployeeBasicInfo { get; set; }
        public required ProcedureBasicInfo ProcedureBasicInfo { get; set; }
        public required SalonBasicInfo SalonBasicInfo { get; set; }
        public required PaymentBasicInfo PaymentBasicInfo { get; set; }
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
        public decimal? Discount { get; set; }
    }
}
