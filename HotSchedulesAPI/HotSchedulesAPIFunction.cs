using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using HotSchedulesAPI.Sources;
using System.Threading.Tasks;

namespace HotSchedulesAPI.Function
{
    public static class HotSchedulesAPIFunction
    {
        [FunctionName("DailyPricesExport")]
        public static async void Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            log.LogInformation("BEGIN GetTimeSeriesDailyAdjusted");

            HotSchedulesAPIClient client = new HotSchedulesAPIClient("GIRGUKTU3NU0IJF3", "compact");
            await client.GetTimeSeriesDailyAdjusted("MSFT");
        }
    }
}
