using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AspNetCore_Middlewares_CoreFx.Samples
{
    public static class ProcessingTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseProcessingTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware(typeof(ProcessingTimeMiddleware));
        }
    }

    public class ProcessingTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ProcessingTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            DateTime start = DateTime.UtcNow;

            context.Response.OnStarting(x =>
            {
                context.Response.Headers.Add("X-Processing-Time", new[] { DateTime.UtcNow.Subtract(start).TotalMilliseconds.ToString("0.00") });
                return Task.CompletedTask;
            }, null);
            
            await _next(context);
        }
    }
}
