using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content("Hello from .NET 9 web app!", "text/plain"));
app.MapGet("/health", () => Results.Json(new { status = "Healthy" }));

app.Run();
