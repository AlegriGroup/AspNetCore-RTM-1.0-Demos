﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCore_Mvc_Docker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                           .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? String.Empty)
                           .UseKestrel()
                           .UseContentRoot(Directory.GetCurrentDirectory() ?? "")
                           .UseIISIntegration()
                           .UseStartup<Startup>()
                           .Build();

            host.Run();
        }
    }
}
