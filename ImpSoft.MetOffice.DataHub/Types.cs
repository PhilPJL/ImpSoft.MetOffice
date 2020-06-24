using ImpSoft.MetOffice.DataHub.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace ImpSoft.MetOffice.DataHub
{
    [DataContract(Name = "")]
    public class Forecast<TDataPoint> where TDataPoint : DataPoint
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "features")]
        public IEnumerable<Feature<TDataPoint>> Features { get; set; }

        [DataMember(Name = "parameters")]
        public IEnumerable<Dictionary<string, ParameterDetails>> Parameters { get; set; }
    }

    public class SimpleForecast<TDataPoint> where TDataPoint : DataPoint
    {
        internal SimpleForecast(Forecast<TDataPoint> forecast)
        {
            var count = forecast?.Features.Count() ?? 0;

            if (count > 1 || count == 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SingleFeatureError, count), nameof(forecast));
            }

            count = forecast?.Parameters.Count() ?? 0;

            if (count > 1)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SingleParameterCollectionError, count), nameof(forecast));
            }

            Type = forecast.Type;
            Feature = forecast.Features.Single();
            Parameters = forecast.Parameters?.Single() ?? new Dictionary<string, ParameterDetails>();
        }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "features")]
        public Feature<TDataPoint> Feature { get; set; }

        [DataMember(Name = "parameters")]
        public Dictionary<string, ParameterDetails> Parameters { get; set; }
    }

    [DataContract(Name = "")]
    public class ParameterDetails
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "unit")]
        public Unit Unit { get; set; }
    }

    [DataContract(Name = "")]
    public class Unit
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "symbol")]
        public Symbol Symbol { get; set; }
    }

    [DataContract(Name = "")]
    public class Symbol
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract(Name = "")]
    public class Feature<TDataPoint> where TDataPoint : DataPoint
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "geometry")]
        public Point Point { get; set; }

        [DataMember(Name = "properties")]
        public Properties<TDataPoint> Properties { get; set; }
    }

    [DataContract(Name = "")]
    public class Point
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "coordinates")]
        public IEnumerable<decimal> Coordinates { get; set; }
    }

    [DataContract(Name = "")]
    public class Properties<TDataPoint> where TDataPoint : DataPoint
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "requestPointDistance")]
        public decimal DistanceFromRequestedPoint { get; set; }

        [DataMember(Name = "modelRunDate")]
        public DateTimeOffset ModelRunDate { get; set; }

        [DataMember(Name = "timeSeries")]
        public IEnumerable<TDataPoint> DataPoints { get; set; }
    }

    [DataContract(Name = "")]
    public class Location
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "licence")]
        public string Licence { get; set; }
    }

    [DataContract(Name = "")]
    public class DataPoint
    {
        private const string TimeKey = "time";

        [DataMember(Name = TimeKey)]
        public DateTimeOffset Time { get; set; }
    }

    [DataContract(Name = "")]
    public class HourlyDataPoint : DataPoint
    {
        public const string ScreenTemperatureKey = "screenTemperature";
        public const string MaxScreenAirTemperatureKey = "maxScreenAirTemp";
        public const string MinScreenAirTemperatureKey = "minScreenAirTemp";
        public const string ScreenDewPointTemperatureKey = "screenDewPointTemperature";
        public const string FeelsLikeTemperatureKey = "feelsLikeTemperature";
        public const string WindSpeed10mKey = "windSpeed10m";
        public const string WindDirectionFrom10mKey = "windDirectionFrom10m";
        public const string WindGustSpeed10mKey = "windGustSpeed10m";
        public const string Max10mWindGustSpeedKey = "max10mWindGust";
        public const string VisibilityKey = "visibility";
        public const string ScreenRelativeHumidityKey = "screenRelativeHumidity";
        public const string MeanSeaLevelPressureKey = "mslp";
        public const string UVIndexKey = "uvIndex";
        public const string SignificantWeatherCodeKey = "significantWeatherCode";
        public const string PrecipitationRateKey = "precipitationRate";
        public const string TotalPrecipitationAmountKey = "totalPrecipAmount";
        public const string TotalSnowAmountKey = "totalSnowAmount";
        public const string ProbabilityOfPrecipitationKey = "probOfPrecipitation";

        [DataMember(Name = ScreenTemperatureKey)]
        public decimal ScreenTemperature { get; set; }

        [DataMember(Name = MaxScreenAirTemperatureKey)]
        public decimal MaxScreenAirTemperature { get; set; }

        [DataMember(Name = MinScreenAirTemperatureKey)]
        public decimal MinScreenAirTemperature { get; set; }

        [DataMember(Name = ScreenDewPointTemperatureKey)]
        public decimal ScreenDewPointTemperature { get; set; }

        [DataMember(Name = FeelsLikeTemperatureKey)]
        public decimal FeelsLikeTemperature { get; set; }

        [DataMember(Name = WindSpeed10mKey)]
        public decimal WindSpeed10m { get; set; }

        [DataMember(Name = WindDirectionFrom10mKey)]
        public int WindDirectionFrom10m { get; set; }

        [DataMember(Name = WindGustSpeed10mKey)]
        public decimal WindGustSpeed10m { get; set; }

        [DataMember(Name = Max10mWindGustSpeedKey)]
        public decimal Max10mWindGustSpeed { get; set; }

        [DataMember(Name = VisibilityKey)]
        public decimal Visibility { get; set; }

        [DataMember(Name = ScreenRelativeHumidityKey)]
        public decimal ScreenRelativeHumidity { get; set; }

        [DataMember(Name = MeanSeaLevelPressureKey)]
        public int MeanSeaLevelPressure { get; set; }

        [DataMember(Name = UVIndexKey)]
        public int UVIndex { get; set; }

        [DataMember(Name = SignificantWeatherCodeKey)]
        public int SignificantWeatherCode { get; set; }

        [DataMember(Name = PrecipitationRateKey)]
        public decimal PrecipitationRate { get; set; }

        [DataMember(Name = TotalPrecipitationAmountKey)]
        public decimal TotalPrecipitationAmount { get; set; }

        [DataMember(Name = TotalSnowAmountKey)]
        public decimal TotalSnowAmount { get; set; }

        [DataMember(Name = ProbabilityOfPrecipitationKey)]
        public int ProbabilityOfPrecipitation { get; set; }
    }

    [DataContract(Name = "")]
    public class ThreeHourlyDataPoint : DataPoint
    {
        public const string MaxScreenAirTemperatureKey = "maxScreenAirTemp";
        public const string MinScreenAirTemperatureKey = "minScreenAirTemp";
        public const string Max10mWindGustSpeedKey = "max10mWindGust";
        public const string SignificantWeatherCodeKey = "significantWeatherCode";
        public const string TotalPrecipitationAmountKey = "totalPrecipAmount";
        public const string TotalSnowAmountKey = "totalSnowAmount";
        public const string WindSpeed10mKey = "windSpeed10m";
        public const string WindDirectionFrom10mKey = "windDirectionFrom10m";
        public const string WindGustSpeed10mKey = "windGustSpeed10m";
        public const string VisibilityKey = "visibility";
        public const string MeanSeaLevelPressureKey = "mslp";
        public const string ScreenRelativeHumidityKey = "screenRelativeHumidity";
        public const string FeelsLikeTemperatureKey = "feelsLikeTemperature";
        public const string UVIndexKey = "uvIndex";
        public const string ProbabilityOfPrecipitationKey = "probOfPrecipitation";
        public const string ProbabilityOfSnowKey = "probOfSnow";
        public const string ProbabilityOfHeavySnowKey = "probOfHeavySnow";
        public const string ProbabilityOfRainKey = "probOfRain";
        public const string ProbabilityOfHeavyRainKey = "probOfHeavyRain";
        public const string ProbabilityOfHailKey = "probOfHail";
        public const string ProbabilityOfAtmosphericsKey = "probOfSferics";

        [DataMember(Name = MaxScreenAirTemperatureKey)]
        public decimal MaxScreenAirTemperature { get; set; }

        [DataMember(Name = MinScreenAirTemperatureKey)]
        public decimal MinScreenAirTemperature { get; set; }

        [DataMember(Name = Max10mWindGustSpeedKey)]
        public decimal Max10mWindGustSpeed { get; set; }

        [DataMember(Name = SignificantWeatherCodeKey)]
        public int SignificantWeatherCode { get; set; }

        [DataMember(Name = TotalPrecipitationAmountKey)]
        public decimal TotalPrecipitationAmount { get; set; }

        [DataMember(Name = TotalSnowAmountKey)]
        public decimal TotalSnowAmount { get; set; }

        [DataMember(Name = WindSpeed10mKey)]
        public decimal WindSpeed10m { get; set; }

        [DataMember(Name = WindDirectionFrom10mKey)]
        public decimal WindDirectionFrom10m { get; set; }

        [DataMember(Name = WindGustSpeed10mKey)]
        public decimal WindGustSpeed10m { get; set; }

        [DataMember(Name = VisibilityKey)]
        public int Visibility { get; set; }

        [DataMember(Name = MeanSeaLevelPressureKey)]
        public int MeanSeaLevelPressure { get; set; }

        [DataMember(Name = ScreenRelativeHumidityKey)]
        public decimal ScreenRelativeHumidity { get; set; }

        [DataMember(Name = FeelsLikeTemperatureKey)]
        public decimal FeelsLikeTemperature { get; set; }

        [DataMember(Name = UVIndexKey)]
        public int UVIndex { get; set; }

        [DataMember(Name = ProbabilityOfPrecipitationKey)]
        public int ProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = ProbabilityOfSnowKey)]
        public int ProbabilityOfSnow { get; set; }

        [DataMember(Name = ProbabilityOfHeavySnowKey)]
        public int ProbabilityOfHeavySnow { get; set; }

        [DataMember(Name = ProbabilityOfRainKey)]
        public int ProbabilityOfRain { get; set; }

        [DataMember(Name = ProbabilityOfHeavyRainKey)]
        public int ProbabilityOfHeavyRain { get; set; }

        [DataMember(Name = ProbabilityOfHailKey)]
        public int ProbabilityOfHail { get; set; }

        [DataMember(Name = ProbabilityOfAtmosphericsKey)]
        public int ProbabilityOfAtmospherics { get; set; }
    }

    [DataContract(Name = "")]
    public class DailyDataPoint : DataPoint
    {
        public const string Midday10mWindSpeedKey = "midday10MWindSpeed";
        public const string Midnight10mWindSpeedKey = "midnight10MWindSpeed";
        public const string Midday10mWindDirectionKey = "midday10MWindDirection";
        public const string Midnight10mWindDirectionKey = "midnight10MWindDirection";
        public const string Midday10mWindGustKey = "midday10MWindGust";
        public const string Midnight10mWindGustKey = "midnight10MWindGust";
        public const string MiddayVisibilityKey = "middayVisibility";
        public const string MidnightVisibilityKey = "midnightVisibility";
        public const string MiddayRelativeHumidityKey = "middayRelativeHumidity";
        public const string MidnightRelativeHumidityKey = "midnightRelativeHumidity";
        public const string MiddayMeanSeaLevelPressureKey = "middayMslp";
        public const string MidnightMeanSeaLevelPressureKey = "midnightMslp";
        public const string MaxUVIndexKey = "maxUvIndex";
        public const string DaySignificantWeatherCodeKey = "daySignificantWeatherCode";
        public const string NightSignificantWeatherCodeKey = "nightSignificantWeatherCode";
        public const string DayMaxScreenTemperatureKey = "dayMaxScreenTemperature";
        public const string NightMinScreenTemperatureKey = "nightMinScreenTemperature";
        public const string DayUpperBoundMaxTemperatureKey = "dayUpperBoundMaxTemp";
        public const string NightUpperBoundMinTemperatureKey = "nightUpperBoundMinTemp";
        public const string DayLowerBoundMaxTemperatureKey = "dayLowerBoundMaxTemp";
        public const string NightLowerBoundMinTemperatureKey = "nightLowerBoundMinTemp";
        public const string DayMaxFeelsLikeTemperatureKey = "dayMaxFeelsLikeTemp";
        public const string NightMinFeelsLikeTemperatureKey = "nightMinFeelsLikeTemp";
        public const string DayUpperBoundMaxFeelsLikeTemperatureKey = "dayUpperBoundMaxFeelsLikeTemp";
        public const string NightUpperBoundMinFeelsLikeTemperatureKey = "nightUpperBoundMinFeelsLikeTemp";
        public const string DayLowerBoundMaxFeelsLikeTemperatureKey = "dayLowerBoundMaxFeelsLikeTemp";
        public const string NightLowerBoundMinFeelsLikeTemperatureKey = "nightLowerBoundMinFeelsLikeTemp";
        public const string DayProbabilityOfPrecipitationKey = "dayProbabilityOfPrecipitation";
        public const string NightProbabilityOfPrecipitationKey = "nightProbabilityOfPrecipitation";
        public const string DayProbabilityOfSnowKey = "dayProbabilityOfSnow";
        public const string NightProbabilityOfSnowKey = "nightProbabilityOfSnow";
        public const string DayProbabilityOfHeavySnowKey = "dayProbabilityOfHeavySnow";
        public const string NightProbabilityOfHeavySnowKey = "nightProbabilityOfHeavySnow";
        public const string DayProbabilityOfRainKey = "dayProbabilityOfRain";
        public const string NightProbabilityOfRainKey = "nightProbabilityOfRain";
        public const string DayProbabilityOfHeavyRainKey = "dayProbabilityOfHeavyRain";
        public const string NightProbabilityOfHeavyRainKey = "nightProbabilityOfHeavyRain";
        public const string DayProbabilityOfHailKey = "dayProbabilityOfHail";
        public const string NightProbabilityOfHailKey = "nightProbabilityOfHail";
        public const string DayProbabilityOfAtmosphericsKey = "dayProbabilityOfSferics";
        public const string NightProbabilityOfAtmosphericsKey = "nightProbabilityOfSferics";

        [DataMember(Name = Midday10mWindSpeedKey)]
        public decimal Midday10mWindSpeed { get; set; }

        [DataMember(Name = Midnight10mWindSpeedKey)]
        public decimal Midnight10mWindSpeed { get; set; }

        [DataMember(Name = Midday10mWindDirectionKey)]
        public int Midday10mWindDirection { get; set; }

        [DataMember(Name = Midnight10mWindDirectionKey)]
        public int Midnight10mWindDirection { get; set; }

        [DataMember(Name = Midday10mWindGustKey)]
        public decimal Midday10mWindGust { get; set; }

        [DataMember(Name = Midnight10mWindGustKey)]
        public decimal Midnight10mWindGust { get; set; }

        [DataMember(Name = MiddayVisibilityKey)]
        public int MiddayVisibility { get; set; }

        [DataMember(Name = MidnightVisibilityKey)]
        public int MidnightVisibility { get; set; }

        [DataMember(Name = MiddayRelativeHumidityKey)]
        public decimal MiddayRelativeHumidity { get; set; }

        [DataMember(Name = MidnightRelativeHumidityKey)]
        public decimal MidnightRelativeHumidity { get; set; }

        [DataMember(Name = MiddayMeanSeaLevelPressureKey)]
        public int MiddayMeanSeaLevelPressure { get; set; }

        [DataMember(Name = MidnightMeanSeaLevelPressureKey)]
        public int MidnightMeanSeaLevelPressure { get; set; }

        [DataMember(Name = MaxUVIndexKey)]
        public int MaxUVIndex { get; set; }

        [DataMember(Name = DaySignificantWeatherCodeKey)]
        public int DaySignificantWeatherCode { get; set; }

        [DataMember(Name = NightSignificantWeatherCodeKey)]
        public int NightSignificantWeatherCode { get; set; }

        [DataMember(Name = DayMaxScreenTemperatureKey)]
        public decimal DayMaxScreenTemperature { get; set; }

        [DataMember(Name = NightMinScreenTemperatureKey)]
        public decimal NightMinScreenTemperature { get; set; }

        [DataMember(Name = DayUpperBoundMaxTemperatureKey)]
        public decimal DayUpperBoundMaxTemperature { get; set; }

        [DataMember(Name = NightUpperBoundMinTemperatureKey)]
        public decimal NightUpperBoundMinTemperature { get; set; }

        [DataMember(Name = DayLowerBoundMaxTemperatureKey)]
        public decimal DayLowerBoundMaxTemperature { get; set; }

        [DataMember(Name = NightLowerBoundMinTemperatureKey)]
        public decimal NightLowerBoundMinTemperature { get; set; }

        [DataMember(Name = DayMaxFeelsLikeTemperatureKey)]
        public decimal DayMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = NightMinFeelsLikeTemperatureKey)]
        public decimal NightMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = DayUpperBoundMaxFeelsLikeTemperatureKey)]
        public decimal DayUpperBoundMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = NightUpperBoundMinFeelsLikeTemperatureKey)]
        public decimal NightUpperBoundMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = DayLowerBoundMaxFeelsLikeTemperatureKey)]
        public decimal DayLowerBoundMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = NightLowerBoundMinFeelsLikeTemperatureKey)]
        public decimal NightLowerBoundMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = DayProbabilityOfPrecipitationKey)]
        public int DayProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = NightProbabilityOfPrecipitationKey)]
        public int NightProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = DayProbabilityOfSnowKey)]
        public int DayProbabilityOfSnow { get; set; }

        [DataMember(Name = NightProbabilityOfSnowKey)]
        public int NightProbabilityOfSnow { get; set; }

        [DataMember(Name = DayProbabilityOfHeavySnowKey)]
        public int DayProbabilityOfHeavySnow { get; set; }

        [DataMember(Name = NightProbabilityOfHeavySnowKey)]
        public int NightProbabilityOfHeavySnow { get; set; }

        [DataMember(Name = DayProbabilityOfRainKey)]
        public int DayProbabilityOfRain { get; set; }

        [DataMember(Name = NightProbabilityOfRainKey)]
        public int NightProbabilityOfRain { get; set; }

        [DataMember(Name = DayProbabilityOfHeavyRainKey)]
        public int DayProbabilityOfHeavyRain { get; set; }

        [DataMember(Name = NightProbabilityOfHeavyRainKey)]
        public int NightProbabilityOfHeavyRain { get; set; }

        [DataMember(Name = DayProbabilityOfHailKey)]
        public int DayProbabilityOfHail { get; set; }

        [DataMember(Name = NightProbabilityOfHailKey)]
        public int NightProbabilityOfHail { get; set; }

        [DataMember(Name = DayProbabilityOfAtmosphericsKey)]
        public int DayProbabilityOfAtmospherics { get; set; }

        [DataMember(Name = NightProbabilityOfAtmosphericsKey)]
        public int NightProbabilityOfAtmospherics { get; set; }
    }
}
