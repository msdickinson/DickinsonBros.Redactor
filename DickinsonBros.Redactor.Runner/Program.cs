using DickinsonBros.Redactor.Abstractions;
using DickinsonBros.Redactor.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DickinsonBros.Redactor.Runner
{
    class Program
    {
        IConfiguration _configuration;
        async static Task Main()
        {
            await new Program().DoMain();
        }
        async Task DoMain()
        {
            try
            {
                var services = InitializeDependencyInjection();
                ConfigureServices(services);
                using (var _applicationLifetime = new Domain.ApplicationLifetime())
                {
                    using (var provider = services.BuildServiceProvider())
                    {
                        var redactorService = provider.GetRequiredService<IRedactorService>();

                        var input =
@"{
  ""Password"": ""password""
}";
                        Console.WriteLine("String:");
                        Console.WriteLine(input);
                        Console.WriteLine();
                        Console.WriteLine("Redacted String:");
                        Console.WriteLine(redactorService.Redact(input));
                        _applicationLifetime.StopApplication();
                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("End...");
                Console.ReadKey();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging(config =>
            {
                config.AddConfiguration(_configuration.GetSection("Logging"));

                if (Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") == "DEBUG")
                {
                    config.AddConsole();
                }
            });

            services.AddSingleton<IApplicationLifetime, Domain.ApplicationLifetime>();
            services.AddSingleton<IRedactorService, RedactorService>();
            services.Configure<JsonRedactorOptions>(_configuration.GetSection(nameof(JsonRedactorOptions)));
        }

        IServiceCollection InitializeDependencyInjection()
        {
            var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true);
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            return services;
        }
    }
}
