using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub
{
    internal class MetOfficeDataHubApi : IMetOfficeDataHubApi
    {
        private string ClientId { get; }
        private string ClientSecret { get; }

        private async Task<TResponse> GetResponseAsync<TResponse>(Uri uri, [CallerMemberName] string caller = null)
        {
            Debug.WriteLine(uri.ToString());

            using (var handler = new HttpClientHandler())
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = uri;

                    client.DefaultRequestHeaders.Add("x-ibm-client-id", ClientId);
                    client.DefaultRequestHeaders.Add("x-ibm-client-secret", ClientSecret);

                    using (var httpResponse = await client.GetAsync(uri))
                    {
                        if (!httpResponse.IsSuccessStatusCode)
                        {
                            // TODO: make this a helper method
                            if (caller?.EndsWith("Async", StringComparison.OrdinalIgnoreCase) ?? false)
                            {
                                caller = caller.Substring(0, caller.Length - 5);
                            }

                            throw new UriGetException($"{caller ?? "Unknown method"}: the HTTP request failed with status code={httpResponse.StatusCode} and reason='{httpResponse.ReasonPhrase}'.", uri);
                        }

                        return JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
                    }
                }
            }
        }

        internal MetOfficeDataHubApi(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        private void AssertValidLatitude(decimal latitude)
        {
            if (latitude < -85m || latitude > 85m)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude must be in the range [-85, 85].");
            }
        }

        private void AssertValidLongitude(decimal longitude)
        {
            if (longitude < -180m || longitude > 180m)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), $"Longitude must be in the range [-180, 180].");
            }
        }

        public async Task<SimpleForecast<DailyDataPoint>> GetDailyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null)
        {
            AssertValidLatitude(latitude);
            AssertValidLongitude(longitude);

            var uri = new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/daily")
                .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                .AddQueryParam("includeLocationName", includeLocationName)
                .AddQueryParam("latitude", latitude)
                .AddQueryParam("longitude", longitude);

            return new SimpleForecast<DailyDataPoint>(await GetResponseAsync<Forecast<DailyDataPoint>>(uri));
        }

        public async Task<SimpleForecast<HourlyDataPoint>> GetHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null)
        {
            AssertValidLatitude(latitude);
            AssertValidLongitude(longitude);

            var uri = new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/hourly")
                .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                .AddQueryParam("includeLocationName", includeLocationName)
                .AddQueryParam("latitude", latitude)
                .AddQueryParam("longitude", longitude);

            return new SimpleForecast<HourlyDataPoint>(await GetResponseAsync<Forecast<HourlyDataPoint>>(uri));
        }

        public async Task<SimpleForecast<ThreeHourlyDataPoint>> GetThreeHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null)
        {
            AssertValidLatitude(latitude);
            AssertValidLongitude(longitude);

            var uri = new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/three-hourly")
                .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                .AddQueryParam("includeLocationName", includeLocationName)
                .AddQueryParam("latitude", latitude)
                .AddQueryParam("longitude", longitude);

            return new SimpleForecast<ThreeHourlyDataPoint>(await GetResponseAsync<Forecast<ThreeHourlyDataPoint>>(uri));
        }
    }
}
