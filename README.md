# Met Office Data Hub API
A simple wrapper for the Met Office Data Hub API for .NET Core and .NET Standard.

## Usage
```C#

  async Task SomeMethodAsync()
  {
  	var clientId = "<my client id>";
	var clientSecret = "<my client secret>";
	
  	var client = MetOfficeDataHubApiFactory.Create(clientId, clientSecret);

	var latitude = 52.239980m;
	var longitude = 0.107120m;

	// get the daily forecast for the specified location (Histon, UK)
	var forecastDaily = await client.GetDailyForecastAsync(latitude, longitude);

	// get the hourly forecast for the specified location (Histon, UK) and retrieve location details 
	// (which are not returned by default)
	var forecastHourly = await client.GetHourlyForecastAsync(latitude, longitude, true);

	// get the daily forecast for the specified location (Histon, UK), retrieve location details 
	// and exclude parameter meta data (which are returned by default)
	var forecastThreeHourly = await client.GetThreeHourlyForecastAsync(latitude, longitude, true, false);
	
	// get a parameter's meta-data
	var dayProbabilityOfHailDetails = forecastDaily.Parameters.GetDetails(DailyDataPoint.DayProbabilityOfHailKey);
	var precipitationRateDetails = forecastHourly.Parameters.GetDetails(HourlyDataPoint.PrecipitationRateKey);
	
	...
  }
```
