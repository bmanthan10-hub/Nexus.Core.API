using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nexus.Core.API.Middlewares
{
    public class CustomLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Requirement: Log path and current time for every request
            string path = context.Request.Path;
            string time = DateTime.Now.ToString("hh:mm tt");

            Console.WriteLine($"-> Path: {path} | Time: {time}");

            await _next(context);
        }
    }
}