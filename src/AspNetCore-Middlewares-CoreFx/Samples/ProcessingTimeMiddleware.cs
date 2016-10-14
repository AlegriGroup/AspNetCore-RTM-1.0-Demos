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

            // Execute
            await _next(context);

            DateTime end = DateTime.UtcNow;

            TimeSpan duration = end - start;
            context.Response.Headers.Add("X-Processing-Time", duration.TotalMilliseconds.ToString("0.00"));
        }
    }
}
