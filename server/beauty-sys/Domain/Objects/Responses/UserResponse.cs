namespace Domain.Objects.Reponses
{
    public record UserResponse
    {
        public required string Name { get; set; }
        public DateTime InsertedAt { get; set; }
    }
}
