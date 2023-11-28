namespace Domain.Objects.Requests
{
    public record UpdateUserRequest
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
