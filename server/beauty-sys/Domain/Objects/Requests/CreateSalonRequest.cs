
namespace Domain.Objects.Requests
{
    public record CreateSalonRequest
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
    }
}
