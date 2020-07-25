using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub
{
    public interface IDataHubClient
    {
        /// <summary>
        /// Retrieve hourly forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
        Task<SimpleForecast<HourlyDataPoint>> GetHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
        /// <summary>
        /// Retrieve three hourly forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
        Task<SimpleForecast<ThreeHourlyDataPoint>> GetThreeHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
        /// <summary>
        /// Retrieve daily forecast data, and optionally metadata for each of the returned values.
        /// </summary>
        /// <param name="latitude">The latitude in the range [-85, 85].</param>
        /// <param name="longitude">The longitude in the range [-180, 180].</param>
        /// <param name="includeLocationName">Optionally request the location name is returned.  The location name won't be returned by default.</param>
        /// <param name="excludeParameterMetadata">Optionally request that parameter metadata is not returned.  Parameter metadata is returned by default.</param>
        /// <returns></returns>
        Task<SimpleForecast<DailyDataPoint>> GetDailyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
    }

    public interface IDataHubClientConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
