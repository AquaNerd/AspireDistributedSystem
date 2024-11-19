using AspireDistributedSystem.ApiService.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AspireDistributedSystem.Tests.UnitTests;

public class WeatherForecastServiceTests
{

    private readonly IWeatherService _sut = new WeatherService();

    [Fact]
    public void GetWeatherForecastReturnsOk()
    {
        var result = _sut.GetWeatherForecast().Result as Ok<WeatherForecast[]>;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.IsAssignableFrom<WeatherForecast[]>(result.Value);
        Assert.True(result.Value.Any());
    }
}
