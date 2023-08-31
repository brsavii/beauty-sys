using Domain.Models.Base;

namespace Domain.Models
{
    public class Customer : BaseModel
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Description { get; set; }
    }
}
