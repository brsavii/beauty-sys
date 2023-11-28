namespace Domain.Objects.Reponses
{
    public record UserResponse
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public DateTime InsertedAt { get; set; }
    }
}
