using Nexus.Core.API.Exceptions;
using Nexus.Core.API.Repositories;
using Nexus.Core.API.Services;
using Serilog;
using Serilog.Events;
using System.Net;
using System.Text.Json;
using YourProjectName.Services;

// Configure Serilog as the logging provider
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId() // Adds thread/request context to each log entry
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Creates a new log file each day
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Use Serilog instead of default .NET logger
builder.Host.UseSerilog();

// Register existing services
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddSingleton<ITimeService, TimeService>();
builder.Services.AddScoped<IRequestCounterService, RequestCounterService>();

// Register Repository Pattern services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global Exception Handling Middleware
// Catches all unhandled exceptions and returns a clean JSON error response
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (ProductNotFoundException ex)
    {
        // Log the error with RequestId for traceability
        Log.Error("Product not found. RequestId: {RequestId}", context.TraceIdentifier);
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        context.Response.ContentType = "application/json";
        var response = JsonSerializer.Serialize(new { message = ex.Message });
        await context.Response.WriteAsync(response);
    }
    catch (Exception ex)
    {
        // Log unexpected errors
        Log.Error(ex, "Unhandled exception. RequestId: {RequestId}", context.TraceIdentifier);
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var response = JsonSerializer.Serialize(new { message = "An unexpected error occurred." });
        await context.Response.WriteAsync(response);
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();