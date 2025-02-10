namespace EmployeeManagerAPI.Middlewares;

public class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;
    public CustomHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Append("X-Custom-Header", "Custom Value");
            context.Response.Headers.Append("X-Request-ID", Guid.CreateVersion7().ToString());
            return Task.CompletedTask;
        });

        await _next(context);
    }
}
