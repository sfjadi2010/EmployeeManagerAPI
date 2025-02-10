using EmployeeManagerAPI.Services;
using System.Text;
using System.Text.Json;

namespace EmployeeManagerAPI.Middlewares;

public class RequestBodyLoggingMiddleware
{
    private readonly RequestDelegate _next;
    public RequestBodyLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        // Enable buffering so that the request can be read multiple times
        context.Request.EnableBuffering();

        // Read the request body stream
        using (var reader = new StreamReader(
            context.Request.Body,
            encoding: Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            bufferSize: 1024,
            leaveOpen: true))
        {
            string requestBody = await reader.ReadToEndAsync();
            JobLogsService.Add($"{context.Request.Method} {context.Request.Path} {JsonSerializer.Serialize(requestBody)}");

            // Reset the stream position to ensure downstream middleware can read it
            context.Request.Body.Position = 0;
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
