namespace Domain.Objects.Reponses
{
    public record CustomerResponse
    {
        public CustomerResponse(string _name, string _phone, string _description)
        {
            Name = _name;
            Phone = _phone;
            Description = _description;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
