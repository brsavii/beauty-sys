namespace Domain.Objects.Reponses
{
    public record CustomerResponse
    {
        public CustomerResponse(int _customerId, string _name, string _phone, string _description)
        {
            CustomerId = _customerId;
            Name = _name;
            Phone = _phone;
            Description = _description;
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
