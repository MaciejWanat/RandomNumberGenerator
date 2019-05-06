using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RandomNumberGenerator.Helpers;
using RandomNumberGenerator.Models.Settings;
using RandomNumberGenerator.Services;

namespace RandomNumberGenerator
{
    public class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            services.AddOptions();
            services.Configure<TestsSettings>(configuration.GetSection(nameof(TestsSettings)));

            services.AddTransient<App>();
            services.AddScoped<ITestRngService, TestRngService>();
            services.AddScoped<IOutputBuilder, OutputBuilder>();
        }

    }
}
