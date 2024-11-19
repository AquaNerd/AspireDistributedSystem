using AspireDistributedSystem.ApiService.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace AspireDistributedSystem.Tests.IntegrationTests;

public class WeatherForecastApiIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{

    private readonly WebApplicationFactory<Program> _factory;

    public WeatherForecastApiIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CanGetWeatherForecasts()
    {
        var client = _factory.CreateClient();

        var result = await client.GetAsync("/api/weatherforecast");

        Assert.NotNull(result);

        Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);

        var content = await result.Content.ReadAsStringAsync();

        Assert.NotEmpty(content);

        var forecasts = await result.Content.ReadFromJsonAsync<WeatherForecast[]>();

        Assert.NotNull(forecasts);
        Assert.NotEmpty(forecasts);
    }
}
