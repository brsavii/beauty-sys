using Domain.Models.Base;

namespace Domain.Models
{
    public class EmployeeProcedure : BaseModel
    {
        public int EmployeeProcedureId { get; set; }
        public int EmployeeId { get; set; }
        public int ProcedureId { get; set; }

        public virtual required Employee Employee { get; set; }
        public virtual required Procedure Procedure { get; set; }
        public virtual Scheduling? Scheduling { get; set; }
    }
}
