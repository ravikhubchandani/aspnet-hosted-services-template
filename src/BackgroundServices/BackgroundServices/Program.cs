using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using System;

namespace BackgroundServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var settings = ReadSettings();

                    services.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();
                        IServiceProvider sp = services.BuildServiceProvider();
                        services.AddLogging(logs => logs.AddConsole());

                        // Add new jobs here
                        q.AddHelloWorldJob(sp, settings);
                    });


                    services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
                });

        private static ApplicationSettings ReadSettings()
        {
            var settings = new ApplicationSettings();
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();
            configuration.GetSection("ApplicationSettings").Bind(settings);
            return settings;
        }
    }
}
