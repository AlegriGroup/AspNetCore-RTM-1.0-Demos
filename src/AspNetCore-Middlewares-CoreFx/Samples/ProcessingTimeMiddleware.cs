using System;
using System.Diagnostics;
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
            var watch = Stopwatch.StartNew();

            context.Response.OnStarting(x =>
            {
                watch.Stop();

                context.Response.Headers.Add("X-Processing-Seconds", new[] { watch.Elapsed.ToString("ss\\.fffffff") });
                return Task.CompletedTask;
            }, null);
            
            await _next(context);
        }
    }
}
