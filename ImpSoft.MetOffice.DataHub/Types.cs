using System;
using System.Collections.Generic;
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
            // TODO: validation and throw 

            Type = forecast.Type;
            Feature = forecast.Features.Single();
            Parameters = forecast.Parameters.Single();
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
        public const string TotalPrecipAmountKey = "totalPrecipAmount";
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

        [DataMember(Name = TotalPrecipAmountKey)]
        public decimal TotalPrecipAmount { get; set; }

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
        [DataMember(Name = "midday10MWindSpeed")]
        public decimal Midday10mWindSpeed { get; set; }

        [DataMember(Name = "midnight10MWindSpeed")]
        public decimal Midnight10mWindSpeed { get; set; }

        [DataMember(Name = "midday10MWindDirection")]
        public int Midday10mWindDirection { get; set; }

        [DataMember(Name = "midnight10MWindDirection")]
        public int Midnight10mWindDirection { get; set; }

        [DataMember(Name = "midday10MWindGust")]
        public decimal Midday10mWindGust { get; set; }

        [DataMember(Name = "midnight10MWindGust")]
        public decimal Midnight10mWindGust { get; set; }

        [DataMember(Name = "middayVisibility")]
        public int MiddayVisibility { get; set; }

        [DataMember(Name = "midnightVisibility")]
        public int MidnightVisibility { get; set; }

        [DataMember(Name = "middayRelativeHumidity")]
        public decimal MiddayRelativeHumidity { get; set; }

        [DataMember(Name = "midnightRelativeHumidity")]
        public decimal MidnightRelativeHumidity { get; set; }

        [DataMember(Name = "middayMslp")]
        public int MiddayMeanSeaLevelPressure { get; set; }

        [DataMember(Name = "midnightMslp")]
        public int MidnightMeanSeaLevelPressure { get; set; }

        [DataMember(Name = "maxUvIndex")]
        public int MaxUVIndex { get; set; }

        [DataMember(Name = "daySignificantWeatherCode")]
        public int DaySignificantWeatherCode { get; set; }

        [DataMember(Name = "nightSignificantWeatherCode")]
        public int NightSignificantWeatherCode { get; set; }

        [DataMember(Name = "dayMaxScreenTemperature")]
        public decimal DayMaxScreenTemperature { get; set; }

        [DataMember(Name = "nightMinScreenTemperature")]
        public decimal NightMinScreenTemperature { get; set; }

        [DataMember(Name = "dayUpperBoundMaxTemp")]
        public decimal DayUpperBoundMaxTemperature { get; set; }

        [DataMember(Name = "nightUpperBoundMinTemp")]
        public decimal NightUpperBoundMinTemperature { get; set; }

        [DataMember(Name = "dayLowerBoundMaxTemp")]
        public decimal DayLowerBoundMaxTemperature { get; set; }

        [DataMember(Name = "nightLowerBoundMinTemp")]
        public decimal NightLowerBoundMinTemperature { get; set; }

        [DataMember(Name = "dayMaxFeelsLikeTemp")]
        public decimal DayMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = "nightMinFeelsLikeTemp")]
        public decimal NightMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = "dayUpperBoundMaxFeelsLikeTemp")]
        public decimal DayUpperBoundMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = "nightUpperBoundMinFeelsLikeTemp")]
        public decimal NightUpperBoundMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = "dayLowerBoundMaxFeelsLikeTemp")]
        public decimal DayLowerBoundMaxFeelsLikeTemperature { get; set; }

        [DataMember(Name = "nightLowerBoundMinFeelsLikeTemp")]
        public decimal NightLowerBoundMinFeelsLikeTemperature { get; set; }

        [DataMember(Name = "dayProbabilityOfPrecipitation")]
        public int DayProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = "nightProbabilityOfPrecipitation")]
        public int NightProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = "dayProbabilityOfSnow")]
        public int DayProbabilityOfSnow { get; set; }

        [DataMember(Name = "nightProbabilityOfSnow")]
        public int NightProbabilityOfSnow { get; set; }

        [DataMember(Name = "dayProbabilityOfHeavySnow")]
        public int DayProbabilityOfHeavySnow { get; set; }

        [DataMember(Name = "nightProbabilityOfHeavySnow")]
        public int NightProbabilityOfHeavySnow { get; set; }

        [DataMember(Name = "dayProbabilityOfRain")]
        public int DayProbabilityOfRain { get; set; }

        [DataMember(Name = "nightProbabilityOfRain")]
        public int NightProbabilityOfRain { get; set; }

        [DataMember(Name = "dayProbabilityOfHeavyRain")]
        public int DayProbabilityOfHeavyRain { get; set; }

        [DataMember(Name = "nightProbabilityOfHeavyRain")]
        public int NightProbabilityOfHeavyRain { get; set; }

        [DataMember(Name = "dayProbabilityOfHail")]
        public int DayProbabilityOfHail { get; set; }

        [DataMember(Name = "nightProbabilityOfHail")]
        public int NightProbabilityOfHail { get; set; }

        [DataMember(Name = "dayProbabilityOfSferics")]
        public int DayProbabilityOfAtmospherics { get; set; }

        [DataMember(Name = "nightProbabilityOfSferics")]
        public int NightProbabilityOfAtmospherics { get; set; }
    }
}
