using Weatherv2.Models;
using Weatherv2.Models.Geocoding;

namespace Weather.Services;
public interface IWeatherService
{
    public  Task<LongLat> GetLongLatAsync(string city, int limit = 1);

    public Task<WeatherApiCall> GetWeatherDataAsync(float lon, float lat);
}
