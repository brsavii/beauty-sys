using Domain.Models.Base;

namespace Domain.Models
{
    public class Salon : BaseModel
    {
        public int SalonId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }

        public virtual ICollection<Scheduling>? Schedulings { get; set; }
    }
}
