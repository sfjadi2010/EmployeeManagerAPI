using EmployeeManagerAPI.Services;

namespace EmployeeManagerAPI.APIs;

public static class JobLogEndpoints
{
    public static WebApplication MapJobLogEndpoints(this WebApplication app)
    {
        app.MapGet("api/joblogs", () =>
        {
            var jobLogs = JobLogsService.GetAll();
            return Results.Ok(jobLogs);
        });
        return app;
    }
}
