using ImpSoft.MetOffice.DataHub.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ImpSoft.MetOffice.DataHub
{
    public class Forecast<TDataPoint> where TDataPoint : DataPoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        public IEnumerable<Feature<TDataPoint>> Features { get; set; }

        [JsonPropertyName("parameters")]
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

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        public Feature<TDataPoint> Feature { get; set; }

        [JsonPropertyName("parameters")]
        public Dictionary<string, ParameterDetails> Parameters { get; set; }
    }

    public class ParameterDetails
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("unit")]
        public Unit Unit { get; set; }
    }

    public class Unit
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("symbol")]
        public Symbol Symbol { get; set; }
    }

    public class Symbol
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Feature<TDataPoint> where TDataPoint : DataPoint
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        public Point Point { get; set; }

        [JsonPropertyName("properties")]
        public Properties<TDataPoint> Properties { get; set; }
    }

    public class Point
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public IEnumerable<decimal> Coordinates { get; set; }
    }

    public class Properties<TDataPoint> where TDataPoint : DataPoint
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("requestPointDistance")]
        public decimal DistanceFromRequestedPoint { get; set; }

        [JsonPropertyName("modelRunDate")]
        public DateTimeOffset ModelRunDate { get; set; }

        [JsonPropertyName("timeSeries")]
        public IEnumerable<TDataPoint> DataPoints { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("licence")]
        public string Licence { get; set; }
    }

    public class DataPoint
    {
        private const string TimeKey = "time";

        [JsonPropertyName(TimeKey)]
        public DateTimeOffset Time { get; set; }
    }

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

        [JsonPropertyName(ScreenTemperatureKey)]
        public decimal ScreenTemperature { get; set; }

        [JsonPropertyName(MaxScreenAirTemperatureKey)]
        public decimal MaxScreenAirTemperature { get; set; }

        [JsonPropertyName(MinScreenAirTemperatureKey)]
        public decimal MinScreenAirTemperature { get; set; }

        [JsonPropertyName(ScreenDewPointTemperatureKey)]
        public decimal ScreenDewPointTemperature { get; set; }

        [JsonPropertyName(FeelsLikeTemperatureKey)]
        public decimal FeelsLikeTemperature { get; set; }

        [JsonPropertyName(WindSpeed10mKey)]
        public decimal WindSpeed10m { get; set; }

        [JsonPropertyName(WindDirectionFrom10mKey)]
        public int WindDirectionFrom10m { get; set; }

        [JsonPropertyName(WindGustSpeed10mKey)]
        public decimal WindGustSpeed10m { get; set; }

        [JsonPropertyName(Max10mWindGustSpeedKey)]
        public decimal Max10mWindGustSpeed { get; set; }

        [JsonPropertyName(VisibilityKey)]
        public decimal Visibility { get; set; }

        [JsonPropertyName(ScreenRelativeHumidityKey)]
        public decimal ScreenRelativeHumidity { get; set; }

        [JsonPropertyName(MeanSeaLevelPressureKey)]
        public int MeanSeaLevelPressure { get; set; }

        [JsonPropertyName(UVIndexKey)]
        public int UVIndex { get; set; }

        [JsonPropertyName(SignificantWeatherCodeKey)]
        public int SignificantWeatherCode { get; set; }

        [JsonPropertyName(PrecipitationRateKey)]
        public decimal PrecipitationRate { get; set; }

        [JsonPropertyName(TotalPrecipitationAmountKey)]
        public decimal TotalPrecipitationAmount { get; set; }

        [JsonPropertyName(TotalSnowAmountKey)]
        public decimal TotalSnowAmount { get; set; }

        [JsonPropertyName(ProbabilityOfPrecipitationKey)]
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

        [JsonPropertyName(MaxScreenAirTemperatureKey)]
        public decimal MaxScreenAirTemperature { get; set; }

        [JsonPropertyName(MinScreenAirTemperatureKey)]
        public decimal MinScreenAirTemperature { get; set; }

        [JsonPropertyName(Max10mWindGustSpeedKey)]
        public decimal Max10mWindGustSpeed { get; set; }

        [JsonPropertyName(SignificantWeatherCodeKey)]
        public int SignificantWeatherCode { get; set; }

        [JsonPropertyName(TotalPrecipitationAmountKey)]
        public decimal TotalPrecipitationAmount { get; set; }

        [JsonPropertyName(TotalSnowAmountKey)]
        public decimal TotalSnowAmount { get; set; }

        [JsonPropertyName(WindSpeed10mKey)]
        public decimal WindSpeed10m { get; set; }

        [JsonPropertyName(WindDirectionFrom10mKey)]
        public decimal WindDirectionFrom10m { get; set; }

        [JsonPropertyName(WindGustSpeed10mKey)]
        public decimal WindGustSpeed10m { get; set; }

        [JsonPropertyName(VisibilityKey)]
        public int Visibility { get; set; }

        [JsonPropertyName(MeanSeaLevelPressureKey)]
        public int MeanSeaLevelPressure { get; set; }

        [JsonPropertyName(ScreenRelativeHumidityKey)]
        public decimal ScreenRelativeHumidity { get; set; }

        [JsonPropertyName(FeelsLikeTemperatureKey)]
        public decimal FeelsLikeTemperature { get; set; }

        [JsonPropertyName(UVIndexKey)]
        public int UVIndex { get; set; }

        [JsonPropertyName(ProbabilityOfPrecipitationKey)]
        public int ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName(ProbabilityOfSnowKey)]
        public int ProbabilityOfSnow { get; set; }

        [JsonPropertyName(ProbabilityOfHeavySnowKey)]
        public int ProbabilityOfHeavySnow { get; set; }

        [JsonPropertyName(ProbabilityOfRainKey)]
        public int ProbabilityOfRain { get; set; }

        [JsonPropertyName(ProbabilityOfHeavyRainKey)]
        public int ProbabilityOfHeavyRain { get; set; }

        [JsonPropertyName(ProbabilityOfHailKey)]
        public int ProbabilityOfHail { get; set; }

        [JsonPropertyName(ProbabilityOfAtmosphericsKey)]
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

        [JsonPropertyName(Midday10mWindSpeedKey)]
        public decimal Midday10mWindSpeed { get; set; }

        [JsonPropertyName(Midnight10mWindSpeedKey)]
        public decimal Midnight10mWindSpeed { get; set; }

        [JsonPropertyName(Midday10mWindDirectionKey)]
        public int Midday10mWindDirection { get; set; }

        [JsonPropertyName(Midnight10mWindDirectionKey)]
        public int Midnight10mWindDirection { get; set; }

        [JsonPropertyName(Midday10mWindGustKey)]
        public decimal Midday10mWindGust { get; set; }

        [JsonPropertyName(Midnight10mWindGustKey)]
        public decimal Midnight10mWindGust { get; set; }

        [JsonPropertyName(MiddayVisibilityKey)]
        public int MiddayVisibility { get; set; }

        [JsonPropertyName(MidnightVisibilityKey)]
        public int MidnightVisibility { get; set; }

        [JsonPropertyName(MiddayRelativeHumidityKey)]
        public decimal MiddayRelativeHumidity { get; set; }

        [JsonPropertyName(MidnightRelativeHumidityKey)]
        public decimal MidnightRelativeHumidity { get; set; }

        [JsonPropertyName(MiddayMeanSeaLevelPressureKey)]
        public int MiddayMeanSeaLevelPressure { get; set; }

        [JsonPropertyName(MidnightMeanSeaLevelPressureKey)]
        public int MidnightMeanSeaLevelPressure { get; set; }

        [JsonPropertyName(MaxUVIndexKey)]
        public int MaxUVIndex { get; set; }

        [JsonPropertyName(DaySignificantWeatherCodeKey)]
        public int DaySignificantWeatherCode { get; set; }

        [JsonPropertyName(NightSignificantWeatherCodeKey)]
        public int NightSignificantWeatherCode { get; set; }

        [JsonPropertyName(DayMaxScreenTemperatureKey)]
        public decimal DayMaxScreenTemperature { get; set; }

        [JsonPropertyName(NightMinScreenTemperatureKey)]
        public decimal NightMinScreenTemperature { get; set; }

        [JsonPropertyName(DayUpperBoundMaxTemperatureKey)]
        public decimal DayUpperBoundMaxTemperature { get; set; }

        [JsonPropertyName(NightUpperBoundMinTemperatureKey)]
        public decimal NightUpperBoundMinTemperature { get; set; }

        [JsonPropertyName(DayLowerBoundMaxTemperatureKey)]
        public decimal DayLowerBoundMaxTemperature { get; set; }

        [JsonPropertyName(NightLowerBoundMinTemperatureKey)]
        public decimal NightLowerBoundMinTemperature { get; set; }

        [JsonPropertyName(DayMaxFeelsLikeTemperatureKey)]
        public decimal DayMaxFeelsLikeTemperature { get; set; }

        [JsonPropertyName(NightMinFeelsLikeTemperatureKey)]
        public decimal NightMinFeelsLikeTemperature { get; set; }

        [JsonPropertyName(DayUpperBoundMaxFeelsLikeTemperatureKey)]
        public decimal DayUpperBoundMaxFeelsLikeTemperature { get; set; }

        [JsonPropertyName(NightUpperBoundMinFeelsLikeTemperatureKey)]
        public decimal NightUpperBoundMinFeelsLikeTemperature { get; set; }

        [JsonPropertyName(DayLowerBoundMaxFeelsLikeTemperatureKey)]
        public decimal DayLowerBoundMaxFeelsLikeTemperature { get; set; }

        [JsonPropertyName(NightLowerBoundMinFeelsLikeTemperatureKey)]
        public decimal NightLowerBoundMinFeelsLikeTemperature { get; set; }

        [JsonPropertyName(DayProbabilityOfPrecipitationKey)]
        public int DayProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName(NightProbabilityOfPrecipitationKey)]
        public int NightProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName(DayProbabilityOfSnowKey)]
        public int DayProbabilityOfSnow { get; set; }

        [JsonPropertyName(NightProbabilityOfSnowKey)]
        public int NightProbabilityOfSnow { get; set; }

        [JsonPropertyName(DayProbabilityOfHeavySnowKey)]
        public int DayProbabilityOfHeavySnow { get; set; }

        [JsonPropertyName(NightProbabilityOfHeavySnowKey)]
        public int NightProbabilityOfHeavySnow { get; set; }

        [JsonPropertyName(DayProbabilityOfRainKey)]
        public int DayProbabilityOfRain { get; set; }

        [JsonPropertyName(NightProbabilityOfRainKey)]
        public int NightProbabilityOfRain { get; set; }

        [JsonPropertyName(DayProbabilityOfHeavyRainKey)]
        public int DayProbabilityOfHeavyRain { get; set; }

        [JsonPropertyName(NightProbabilityOfHeavyRainKey)]
        public int NightProbabilityOfHeavyRain { get; set; }

        [JsonPropertyName(DayProbabilityOfHailKey)]
        public int DayProbabilityOfHail { get; set; }

        [JsonPropertyName(NightProbabilityOfHailKey)]
        public int NightProbabilityOfHail { get; set; }

        [JsonPropertyName(DayProbabilityOfAtmosphericsKey)]
        public int DayProbabilityOfAtmospherics { get; set; }

        [JsonPropertyName(NightProbabilityOfAtmosphericsKey)]
        public int NightProbabilityOfAtmospherics { get; set; }
    }
}
