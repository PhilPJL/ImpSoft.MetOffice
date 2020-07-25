using ImpSoft.MetOffice.DataHub.Properties;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub
{
    public class DataHubClient : IDataHubClient
    {
        private HttpClient Client { get; }
        private IDataHubClientConfiguration Configuration { get; }

        public DataHubClient(HttpClient client, IDataHubClientConfiguration configuration = null)
        {
            Preconditions.IsNotNull(client, nameof(client));

            Client = client;
            Configuration = configuration;
        }

        private async Task<TResponse> GetResponseAsync<TResponse>(Uri uri)
        {
            Debug.WriteLine(uri.ToString());

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri
            };

            // NOTE: if Configuration isn't provided the authorization headers must be set externally (e.g. by HttpClientHandler)
            if (Configuration != null)
            {
                request.Headers.Add("x-ibm-client-id", Configuration.ClientId);
                request.Headers.Add("x-ibm-client-secret", Configuration.ClientSecret);
            }

            using (var httpResponse = await Client.SendAsync(request))
            {
                httpResponse.EnsureSuccessStatusCode();

                return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
            }
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

            var uri = ComposeGetDailyForecastUri(latitude, longitude, includeLocationName, excludeParameterMetadata);

            return new SimpleForecast<DailyDataPoint>(await GetResponseAsync<Forecast<DailyDataPoint>>(uri));
        }

        internal static Uri ComposeGetDailyForecastUri(decimal latitude, decimal longitude, bool? includeLocationName, bool? excludeParameterMetadata)
        {
            return new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/daily")
                            .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                            .AddQueryParam("includeLocationName", includeLocationName)
                            .AddQueryParam("latitude", latitude)
                            .AddQueryParam("longitude", longitude);
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

            var uri = ComposeGetHourlyForecastUri(latitude, longitude, includeLocationName, excludeParameterMetadata);

            return new SimpleForecast<HourlyDataPoint>(await GetResponseAsync<Forecast<HourlyDataPoint>>(uri));
        }

        internal static Uri ComposeGetHourlyForecastUri(decimal latitude, decimal longitude, bool? includeLocationName, bool? excludeParameterMetadata)
        {
            return new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/hourly")
                            .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                            .AddQueryParam("includeLocationName", includeLocationName)
                            .AddQueryParam("latitude", latitude)
                            .AddQueryParam("longitude", longitude);
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

            var uri = ComposeGetThreeHourlyForecastUri(latitude, longitude, includeLocationName, excludeParameterMetadata);

            return new SimpleForecast<ThreeHourlyDataPoint>(await GetResponseAsync<Forecast<ThreeHourlyDataPoint>>(uri));
        }

        internal static Uri ComposeGetThreeHourlyForecastUri(decimal latitude, decimal longitude, bool? includeLocationName, bool? excludeParameterMetadata)
        {
            return new Uri(@"https://api-metoffice.apiconnect.ibmcloud.com/metoffice/production/v0/forecasts/point/three-hourly")
                            .AddQueryParam("excludeParameterMetadata", excludeParameterMetadata)
                            .AddQueryParam("includeLocationName", includeLocationName)
                            .AddQueryParam("latitude", latitude)
                            .AddQueryParam("longitude", longitude);
        }
    }
}
