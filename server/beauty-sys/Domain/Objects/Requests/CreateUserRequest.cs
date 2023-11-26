namespace Domain.Objects.Requests
{
    public record CreateUserRequest
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
