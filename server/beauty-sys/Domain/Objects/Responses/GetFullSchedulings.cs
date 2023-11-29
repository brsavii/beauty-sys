namespace Domain.Objects.Responses
{
    public record GetFullSchedulings
    {
        public int Day { get; set; }
        public int? SchedulingId { get; set; }
        public DateTime StartDateTime { get; set; }
        public decimal TotalValue { get; set; }
        public CustomerBasicInfo? CustomerBasicInfo { get; set; }
        public EmployeeBasicInfo? EmployeeBasicInfo { get; set; }
        public ProcedureBasicInfo? ProcedureBasicInfo { get; set; }
        public SalonBasicInfo? SalonBasicInfo { get; set; }
        public PaymentBasicInfo? PaymentBasicInfo { get; set; }
    }
}
