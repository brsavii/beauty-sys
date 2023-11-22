namespace Domain.Objects.Responses
{
    public record GetSchedulingDetailResponse
    {
        public int CurrentCustomerId { get; set; }
        public int CurrentEmployeeId { get; set; }
        public int CurrentProcedureId { get; set; }
        public required ICollection<CustomerBasicInfo> Customers { get; set; }
        public required ICollection<EmployeeBasicInfo> Employees { get; set; }
        public required ICollection<ProcedureBasicInfo> Procedures { get; set; }
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
        public required string CustomerName { get; set; }
    }

    public record EmployeeBasicInfo
    {
        public int EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
    }

    public record ProcedureBasicInfo
    {
        public int ProcedureId { get; set; }
        public required string ProcedureName { get; set; }
    }
}
