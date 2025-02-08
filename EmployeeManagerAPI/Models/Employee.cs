namespace EmployeeManagerAPI.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Salary { get; set; }
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Phone { get; set; } = default!;
}
