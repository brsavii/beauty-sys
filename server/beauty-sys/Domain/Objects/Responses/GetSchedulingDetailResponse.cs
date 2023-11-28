namespace Domain.Objects.Responses
{
    public record GetSchedulingDetailResponse
    {
        public int Day { get; set; }
        public decimal Value { get; set; }
        public required string SalonName { get; set; }
        public required CustomerBasicInfo CustomerBasicInfo { get; set; }
        public required EmployeeBasicInfo EmployeeBasicInfo { get; set; }
        public required ProcedureBasicInfo ProcedureBasicInfo { get; set; }
    }

    public record SchedulingDetailsIds
    {
        public int CurrentCustomerId { get; set; }
        public int CurrentEmployeeId { get; set; }
        public int CurrentProcedureId { get; set; }
    }

    public record CustomerBasicInfo
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
    }

    public record EmployeeBasicInfo
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Office { get; set; }
        public required string Cpf { get; set; }
        public required string JobPositionName { get; set; }
    }

    public record ProcedureBasicInfo
    {
        public int ProcedureId { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public int ProcedureTime { get; set; }
    }
}
