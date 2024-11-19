using AspireDistributedSystem.ApiService.Services;

namespace AspireDistributedSystem.ApiService.Endpoints;

public static class WeatherForecastEndpoints
{

    public static void AddWeatherForecastEndpoints(this WebApplication app)
    {
        app.MapGet("/api/weatherforecast", (IWeatherService weatherService) => weatherService.GetWeatherForecast()).WithName("GetWeatherForecast");
    }

}
