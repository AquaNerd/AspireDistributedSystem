using Microsoft.AspNetCore.Http.HttpResults;

namespace AspireDistributedSystem.ApiService.Services;

public interface IWeatherService
{
    Results<Ok, NotFound> DeleteForecast(int id);
    Results<Ok<WeatherForecast[]>, ProblemHttpResult> GetWeatherForecasts();
}

public class WeatherService : IWeatherService
{
    string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    public Results<Ok<WeatherForecast[]>, ProblemHttpResult> GetWeatherForecasts()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
        return TypedResults.Ok(forecast);
    }

    public Results<Ok, NotFound> DeleteForecast(int id)
    {
        if (id <= 0)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok();
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
