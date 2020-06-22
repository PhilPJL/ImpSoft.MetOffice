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

	  var forecast = await client.GetDailyForecastAsync(latitude, longitude, true);


  }
```
