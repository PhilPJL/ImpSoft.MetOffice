# Met Office Data Hub API
A simple .NET Core and .NET Standard client for the Met Office Data Hub API.

## Usage
```C#

  async Task SomeMethodAsync()
  {
  	var clientId = "<my client id>";
	var clientSecret = "<my client secret>";
	
  	var client = DataHubClientFactory.Create(clientId, clientSecret);

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
	var dayProbabilityOfHailDetails = forecastDaily
		.Parameters.GetDetails(DailyDataPoint.DayProbabilityOfHailKey);
	var precipitationRateDetails = forecastHourly
		.Parameters.GetDetails(HourlyDataPoint.PrecipitationRateKey);
	
	...
  }
```

See https://metoffice.apiconnect.ibmcloud.com/metoffice/production/api for more information on the Met Office API.

The project uses one or more icons made by <a href="https://www.flaticon.com/authors/flat-icons" title="Flat Icons">Flat Icons</a> from <a href="https://www.flaticon.com/" title="Flaticon"> www.flaticon.com</a>
