namespace Domain.Objects.Reponses
{
    public record LogInResponse
    {
        public string UserName { get; set; }
        public string AuthToken { get; set; }
    }
}
