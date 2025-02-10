using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Services;

public static class JobLogsService
{
    private static List<JobLog> _jobLogs = new();
    private static int _nextId = 1;
    public static void Add(string message)
    {
        var jobLog = new JobLog
        {
            Id = _nextId++,
            Message = message,
            Timestamp = DateTime.UtcNow
        };
        _jobLogs.Add(jobLog);
    }
    public static List<JobLog> GetAll()
    {
        return _jobLogs;
    }
}
