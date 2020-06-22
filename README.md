# Met Office Data Hub API
A simple wrapper for the Met Office Data Hub API for .NET Core and .NET Standard.

# Usage
```C#

  async Task SomeMethod()
  {
  	var clientId = "<my client id>";
	var clientSecret = "<my client secret>";
	
  	var client = MetOfficeDataHubApiFactory.Create(clientId, clientSecret);

	var latitude = 52.239980m;
	var longitude = 0.107120m;

	// get the daily forecast for the specified location (Histon, UK)
	var forecast = await client.GetDailyForecastAsync(latitude, longitude);

	// get the daily forecast for the specified location (Histon, UK) and retrieve location details (not returned by default)
	var forecast1 = await client.GetDailyForecastAsync(latitude, longitude, true);

	// get the daily forecast for the specified location (Histon, UK), retrieve location details and 
	// exclude parameter meta data (returned by default)
	var forecast2 = await client.GetDailyForecastAsync(latitude, longitude, true, false);
	
	// get a parameter's meta data
	var parameterDetails = forecast.Parameters.GetDetails(DailyDataPoint.DayProbabilityOfHailKey);
	
	...
  }
```
