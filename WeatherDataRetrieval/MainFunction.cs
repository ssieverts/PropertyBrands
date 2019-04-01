using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WeatherDataDal.Models;

namespace WeatherDataRetrieval
{
    /// <summary>
    ///     Main entry point
    /// </summary>
    public static class MainFunction
    {
        private static readonly ILoggerFactory loggerFactory = new LoggerFactory();
        private static readonly ILogger log = loggerFactory.CreateLogger("MainFunction");
        private static readonly WeatherDataContext context = new WeatherDataContext();

        [FunctionName("MainFunction")]
        public static async Task RunAsync([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            try
            {
                var job = new GetWeatherData(context, log);
                await job.Run();

                log.LogInformation($"MainFunction Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.LogError("Configure-Failed: {0}", ex.Message);
            }
        }
    }
}