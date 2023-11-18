
using Domain.Models.Base;

namespace Domain.Models
{
    public class Scheduling : BaseModel
    {
        public int SchedulingId { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeProcedureId { get; set; }

        public virtual required Customer Customer { get; set; }
        public virtual required EmployeeProcedure EmployeeProcedure { get; set; }
    }
}
