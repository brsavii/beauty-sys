using Domain.Models.Base;

namespace Domain.Models
{
    public class Employee : BaseModel
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Office { get; set; }
        public required string Cpf { get; set; }
        public virtual required ICollection<EmployeeProcedure> EmployeeProcedures { get; set; }
    }
}
