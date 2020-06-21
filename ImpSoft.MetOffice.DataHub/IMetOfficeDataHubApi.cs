using System.Threading.Tasks;

namespace ImpSoft.MetOffice.DataHub
{
    public interface IMetOfficeDataHubApi
    {
        Task<SimpleForecast<HourlyDataPoint>> GetHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
        Task<SimpleForecast<ThreeHourlyDataPoint>> GetThreeHourlyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
        Task<SimpleForecast<DailyDataPoint>> GetDailyForecastAsync(decimal latitude, decimal longitude, bool? includeLocationName = null, bool? excludeParameterMetadata = null);
    }
}
