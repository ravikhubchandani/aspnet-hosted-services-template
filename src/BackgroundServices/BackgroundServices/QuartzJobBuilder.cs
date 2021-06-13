using BackgroundServices.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;

namespace BackgroundServices
{
    public static class QuartzJobBuilder
    {
        public static void AddHelloWorldJob(this IServiceCollectionQuartzConfigurator quartz, IServiceProvider injector, ApplicationSettings settings)
        {
            JobDataMap data = new JobDataMap();
            data.Add("logger", injector.GetRequiredService<ILogger<HelloWorldService>>());
            quartz.AddMappedJob<HelloWorldService>(data, HelloWorldService.ServiceName, settings.HelloWorldTimer);
        }

        private static void AddMappedJob<T>(this IServiceCollectionQuartzConfigurator quartz, JobDataMap data, string serviceName, string serviceSchedule) where T : IJob
        {
            var jobKey = new JobKey($"{serviceName}{Guid.NewGuid()}");
            quartz.AddJob<T>(o => o.WithIdentity(jobKey));
            quartz.AddTrigger(o => o
                .ForJob(jobKey)
                .WithCronSchedule(serviceSchedule)
                .UsingJobData(data)
            );
        }
    }
}
