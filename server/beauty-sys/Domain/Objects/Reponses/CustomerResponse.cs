namespace Domain.Objects.Reponses
{
    public record CustomerResponse
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Description { get; set; }
    }
}
