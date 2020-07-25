using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub.Tests
{
    [TestClass]
    public class DailyTests
    {
        [TestMethod]
        public async Task GetDailyForecastSucceedsAsync()
        {
            var latitude = 52.239980m;
            var longitude = 0.107120m;

            var uri = DataHubClient.ComposeGetDailyForecastUri(latitude, longitude, null, null);

            var forecast = new Forecast<DailyDataPoint>
            {
                Features = new List<Feature<DailyDataPoint>>
                {
                    new Feature<DailyDataPoint>
                    {
                        // TODO
                    }
                },
                Parameters = new List<Dictionary<string, ParameterDetails>>
                {
                    // TODO
                    new Dictionary<string, ParameterDetails>
                    {
                        // TOOD
                    }
                },
                Type = "Daily"
            };

            var client = TestHelper.CreateClient(uri, forecast);

            var response = await client.GetDailyForecastAsync(latitude, longitude);

            Assert.AreEqual(forecast.Type, response.Type);
        }
    }
}
