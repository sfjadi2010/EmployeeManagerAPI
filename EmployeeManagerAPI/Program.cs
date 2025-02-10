using EmployeeManagerAPI.APIs;
using EmployeeManagerAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<CustomHeaderMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();
app.UseMiddleware<RequestBodyLoggingMiddleware>();

// Map endpoints to the app
app.MapGets();
app.MapPosts();
app.MapPuts();
app.MapPatches();
app.MapDeteles();

app.MapJobLogEndpoints();

app.Run();
