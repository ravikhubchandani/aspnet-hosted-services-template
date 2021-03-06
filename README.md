# aspnet-hosted-services-template
Template for processes to run in background based on a cron schedule 

## Add a new scheduled job
1. Write a new Quartz IJob in the BackgroundServices.Jobs namespace (https://github.com/ravikhubchandani/aspnet-hosted-services-template/tree/master/src/BackgroundServices/BackgroundServices/Jobs) OR import a reference to an already existing IJob
2. Define schedule trigger and data to relay for the job in QuartzJobBuilder (https://github.com/ravikhubchandani/aspnet-hosted-services-template/blob/master/src/BackgroundServices/BackgroundServices/QuartzJobBuilder.cs)
3. Add job details produced in the previous step in the job list to run (https://github.com/ravikhubchandani/aspnet-hosted-services-template/blob/master/src/BackgroundServices/BackgroundServices/Program.cs)

## Extra
* Add dependency resolvers in Program.cs https://github.com/ravikhubchandani/aspnet-hosted-services-template/blob/master/src/BackgroundServices/BackgroundServices/Program.cs
* Add settings entries in appsettings.json (https://github.com/ravikhubchandani/aspnet-hosted-services-template/blob/master/src/BackgroundServices/BackgroundServices/appsettings.json) and ApplicationSettings.cs (https://github.com/ravikhubchandani/aspnet-hosted-services-template/blob/master/src/BackgroundServices/BackgroundServices/ApplicationSettings.cs)
