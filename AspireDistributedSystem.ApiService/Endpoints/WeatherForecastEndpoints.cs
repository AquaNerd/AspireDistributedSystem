using AspireDistributedSystem.ApiService.Auth;
using AspireDistributedSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspireDistributedSystem.ApiService.Endpoints;

public static class WeatherForecastEndpoints
{

    public static void AddWeatherForecastEndpoints(this WebApplication app)
    {
        var weatherForecastGroup = app.MapGroup("/api/weatherforecast").RequireAuthorization();

        weatherForecastGroup.MapGet("/", (IWeatherService weatherService) => weatherService.GetWeatherForecasts())
            .WithName("Get Weather Forecasts")
            .WithSummary("Will return a collection of Weather Forecasts");

        weatherForecastGroup.MapDelete("/{id}", ([FromServices] IWeatherService weatherService, [FromRoute] int id) => weatherService.DeleteForecast(id))
            .WithName("Delete Forecast")
            .WithSummary("Deletes a single weather forecast")
            .RequireAuthorization(IdentityData.AdminUserPolicyName);
    }

}
