using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostBasedConsoleApp
{
    class Program
    {
        static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var workerInstance = host.Services.GetRequiredService<Worker>();
            workerInstance.Execute();
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddTransient<Worker>();
            })
            .ConfigureLogging((_, logging) => 
            {
                logging.ClearProviders();
                logging.AddSimpleConsole(options => options.IncludeScopes = true);
                logging.AddEventLog();
            });
    }
}
