namespace EmployeeManagerAPI.Models;

public class JobLog
{
    public int Id { get; set; }
    public string Message { get; set; } = default!;
    public DateTime Timestamp { get; set; }
}
