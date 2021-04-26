using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIConsoleDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            ExecuteScope(host.Services, "sample-scope-1");
            ExecuteScope(host.Services, "sample-scope-2");
            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<ITransientGetCreatedTime, GetCreatedTimeImplementation>()
                            .AddScoped<IScopedGetCreatedTime, GetCreatedTimeImplementation>()
                            .AddSingleton<ISingletonGetCreatedTime, GetCreatedTimeImplementation>()
                            .AddTransient<GetCreatedTimeInvoker>());


        static void ExecuteScope(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            Console.WriteLine("===================================================");
            Console.WriteLine($"Scope Name: {scope}");
            Console.WriteLine("===================================================");
            Console.WriteLine($"First Call....");
            GetCreatedTimeInvoker invoker = provider.GetRequiredService<GetCreatedTimeInvoker>();
            invoker.Invoke();

            Console.WriteLine("...");
            Console.WriteLine($"Second Call....");
            invoker = provider.GetRequiredService<GetCreatedTimeInvoker>();
            invoker.Invoke();

            Console.WriteLine("===================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
