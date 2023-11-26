namespace Domain.Objects.Requests
{
    public record UpdateUserRequest
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
