using Microsoft.AspNetCore.Builder;

namespace Nexus.Core.API.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLoggingMiddleware>();
        }
    }
}