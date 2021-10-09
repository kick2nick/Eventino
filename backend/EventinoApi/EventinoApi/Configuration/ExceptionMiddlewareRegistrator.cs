using EventinoApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace EventinoApi.Configuration
{
    public static class ExceptionMiddlewareRegistrator
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
