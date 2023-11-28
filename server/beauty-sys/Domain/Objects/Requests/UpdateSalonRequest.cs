namespace Domain.Objects.Requests
{
    public record UpdateSalonRequest
    {
        public int SalonId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
