using ImpSoft.MetOffice.DataHub.Properties;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub
{
    internal class DataHubClient : IDataHubClient
    {
        private string ClientId { get; }
        private string ClientSecret { get; }

        private async Task<TResponse> GetResponseAsync<TResponse>(Uri uri, [CallerMemberName] string caller = null)
        {
            Debug.WriteLine(uri.ToString());

            using (var handler = new HttpClientHandler())
            {
#if NETCOREAPP
                handler.AutomaticDecompression = DecompressionMethods.All;
#else
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
#endif
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = uri;

                    client.DefaultRequestHeaders.Add("x-ibm-client-id", ClientId);
                    client.DefaultRequestHeaders.Add("x-ibm-client-secret", ClientSecret);

                    using (var httpResponse = await client.GetAsync(uri))
                    {
                        if (!httpResponse.IsSuccessStatusCode)
                        {
                            caller = caller.StripAsyncSuffix();

                            var message = string.Format(CultureInfo.CurrentCulture,
                                Resources.HttpRequestFailed, caller ?? Resources.UnknownMethod, httpResponse.StatusCode, httpResponse.ReasonPhrase);

                            throw new UriGetException(message, uri);
                        }

                        return JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
                    }
                }
            }
        }

        internal DataHubClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        private static void AssertValidLatitude(decimal latitude)
        {
            if (latitude < -85m || latitude > 85m)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude), latitude, Resources.LatitudeError);
            }
        }

        private static void AssertValidLongitude(decimal longitude)
        {
            if (longitude < -180m || longitude > 180m)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude), longitude, Resources.LongitudeError);
            }
        }

        /// <summary>
        /// Retrieve daily forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieve hourly forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieve three hourly forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
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
