
using Domain.Models.Base;

namespace Domain.Models
{
    public class JobPosition : BaseModel
    {
        public int JobPositionId { get; set; }
        public required string Name { get; set; }
        public required decimal Salary { get; set; }
    }
}
