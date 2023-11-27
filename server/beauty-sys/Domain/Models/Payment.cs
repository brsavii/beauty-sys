using Domain.Models.Base;

namespace Domain.Models
{
    public class Payment : BaseModel
    {
        public int PaymentId { get; set; }
        public required string Name { get; set; }
        public decimal? Discount { get; set; }

        public virtual ICollection<Scheduling>? Schedulings { get; set; }
    }
}
