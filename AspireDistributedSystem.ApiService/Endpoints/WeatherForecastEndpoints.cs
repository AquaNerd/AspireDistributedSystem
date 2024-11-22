using AspireDistributedSystem.ApiService.Services;

namespace AspireDistributedSystem.ApiService.Endpoints;

public static class WeatherForecastEndpoints
{

    public static void AddWeatherForecastEndpoints(this WebApplication app)
    {
        var weatherForecastGroup = app.MapGroup("/api/weatherforecast").RequireAuthorization();

        weatherForecastGroup.MapGet("/", (IWeatherService weatherService) => weatherService.GetWeatherForecast())
            .WithName("Get Weather Forecasts")
            .WithSummary("Will return a collection of Weather Forecasts");
    }

}
