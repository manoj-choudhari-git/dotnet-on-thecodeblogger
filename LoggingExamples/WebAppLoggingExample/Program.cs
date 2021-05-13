using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAppLoggingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureLogging((hostingContext, loggingBuilder) =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddJsonConsole(options =>
                        {
                            options.IncludeScopes = false;
                            options.TimestampFormat = "hh:mm:ss ";
                            options.JsonWriterOptions = new JsonWriterOptions
                            {
                                Indented = true
                            };
                        });
                        // Application Insights
                        loggingBuilder.AddApplicationInsights(instrumentationKey: "");

                        // Azure App Service Diagnostics
                        loggingBuilder.AddAzureWebAppDiagnostics();
                    });
                });
    }
}
