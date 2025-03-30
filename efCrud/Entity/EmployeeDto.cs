namespace efCrud.Entity
{
    public class EmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
    }
}
