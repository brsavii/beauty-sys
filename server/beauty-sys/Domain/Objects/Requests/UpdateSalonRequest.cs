namespace Domain.Objects.Requests
{
    public record UpdateSalonRequest
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
