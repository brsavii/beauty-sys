
using Domain.Models.Base;

namespace Domain.Models
{
    public class User : BaseModel
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
