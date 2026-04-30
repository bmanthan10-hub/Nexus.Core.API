using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Nexus.Core.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// 1. Basic Middleware: Request Start/Finish Log
app.Use(async (context, next) =>
{
    Console.WriteLine("-> Request started");
    await next();
    Console.WriteLine("-> Request finished");
});

// 2. Terminal Middleware (Run): Handle /stop
app.Map("/stop", (appBuilder) =>
{
    appBuilder.Run(async (context) =>
    {
        await context.Response.WriteAsync("Response returned: Request stopped by middleware");
    });
});

// 3. Conditional Custom Middleware: UseWhen for /api
app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseCustomLogging(); // Extension method used here
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();