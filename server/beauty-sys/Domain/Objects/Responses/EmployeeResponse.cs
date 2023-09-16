namespace Domain.Objects.Reponses
{
    public record EmployeeResponse
    {
        public EmployeeResponse(int _employeeId, string _name, string _cpf)
        {
            EmployeeId = _employeeId;
            Name = _name;
            Cpf = _cpf;
        }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
    }
}
