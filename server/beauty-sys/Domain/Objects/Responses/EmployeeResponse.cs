namespace Domain.Objects.Reponses
{
    public record EmployeeResponse
    {
        public EmployeeResponse(int _employeeId, string _name, string _cpf, string _office)
        {
            EmployeeId = _employeeId;
            Name = _name;
            Cpf = _cpf;
            Office = _office;
        }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Office { get; set; }
    }
}
