using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_Middlewares_CoreFx.Samples;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCore_Middlewares_CoreFx
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            // ===== Demo Middlewares


            app.UseProcessingTime();

            //app.UseSimulatedLatency(
            //    min: TimeSpan.FromMilliseconds(10),
            //    max: TimeSpan.FromMilliseconds(500));


            //app.UseWhen(context => !context.Request.Path.StartsWithSegments(new PathString("/api")), branch => {
            //    // Register the status code middleware, but only for non-API calls.
            //    branch.UseStatusCodePagesWithReExecute("/error/{0}");
            //});


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }
    }
}
