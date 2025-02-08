using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Services;

namespace EmployeeManagerAPI.APIs;

public static class EmployeeEndpoints
{
    public static WebApplication MapGets(this WebApplication app)
    {
        app.MapGet("api/employee/{id}", (int id) =>
        {
            var employee = EmployeeService.Get(id);
            return Results.Ok(employee);
        });

        return app;
    }

    public static WebApplication MapPosts(this WebApplication app)
    {
        app.MapPost("api/employee", (Employee employee) =>
        {
            EmployeeService.Create(employee);
            return Results.Created();
        });
        return app;
    }

    public static WebApplication MapPuts(this WebApplication app)
    {
        app.MapPut("api/employee", (Employee employee) =>
        {
            EmployeeService.Update(employee);
            return Results.NoContent();
        });

        return app;
    }

    public static WebApplication MapPatches(this WebApplication app)
    {
        app.MapPatch("api/employee/{id}", (int id, string name) =>
        {
            EmployeeService.ChangeName(id, name);
            return Results.NoContent();
        });
        return app;
    }

    public static WebApplication MapDeteles(this WebApplication app)
    {
        app.MapDelete("api/employee/{id}", (int id) =>
        {
            EmployeeService.Delete(id);
            return Results.NoContent();
        });

        return app;
    }
}
