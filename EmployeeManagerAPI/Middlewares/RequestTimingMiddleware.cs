using System.Diagnostics;

namespace EmployeeManagerAPI.Middlewares;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        context.Response.OnStarting(() =>
        {
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            context.Response.Headers.Append("X-Processing-Time-Milliseconds", elapsedMilliseconds.ToString());
            return Task.CompletedTask;
        });

        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation($"Request processing time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
