using Domain.Models.Base;

namespace Domain.Models
{
    public class Procedure : BaseModel
    {
        public int ProcedureId { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public virtual required ICollection<Employee> Employees { get; set; }
    }
}
