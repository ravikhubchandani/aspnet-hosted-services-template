using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;

namespace BackgroundServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting background services");
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
