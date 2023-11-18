namespace Domain.Objects.Requests
{
    public record LogInRequest
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }

    }
}
