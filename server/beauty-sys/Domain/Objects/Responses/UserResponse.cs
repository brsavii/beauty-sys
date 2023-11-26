namespace Domain.Objects.Reponses
{
    public record UserResponse
    {
        public string Name { get; set; }
        public DateTime InsertedAt { get; set; }
    }
}
