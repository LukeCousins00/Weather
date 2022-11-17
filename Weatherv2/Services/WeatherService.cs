using System.Text.Json;
using Weather.Models;
using Weatherv2.Models;
using Weatherv2.Models.Geocoding;

namespace Weather.Services;
public class WeatherService : IWeatherService
{
    private readonly HttpClient _weatherClient;
    private readonly IConfiguration _configuration;

    public WeatherService(HttpClient weatherClient, IConfiguration configuration)
    {
        _weatherClient = weatherClient;
        _configuration = configuration;
    }

    public async Task<LongLat> GetLongLatAsync(string city, int limit = 1)
    {
        HttpResponseMessage geocodingResponse = await _weatherClient.GetAsync(
            $"/geo/1.0/direct?q=/{city}&limit={limit}&appid={_configuration.GetValue<string>("ApiKey")}");

        geocodingResponse.EnsureSuccessStatusCode();

        var geocoding = JsonSerializer.Deserialize<List<Geocode>>(await geocodingResponse.Content.ReadAsStringAsync());

        if (geocoding.Count < 1)
        {
            // failed to find co-ordinates for location
            return null;
        }

        return new LongLat { 
            Longitude = (decimal)geocoding[0].Longitude,
            Latitude = (decimal)geocoding[0].Latitude
        };
    }

    public async Task<WeatherApiCall> GetWeatherDataAsync(float lon, float lat)
    {
        HttpResponseMessage weatherApiResponse = await _weatherClient.GetAsync(
            $"/data/2.5/weather?lat={lat}&lon={lon}&appid={_configuration.GetValue<string>("ApiKey")}");

        weatherApiResponse.EnsureSuccessStatusCode();

        WeatherApiCall weather = JsonSerializer.Deserialize<WeatherApiCall>(await weatherApiResponse.Content.ReadAsStringAsync());

        return weather;
    }
}