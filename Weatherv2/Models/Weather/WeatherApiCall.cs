using System.Text.Json.Serialization;
using Weather.Models;

namespace Weatherv2.Models;

public class WeatherApiCall
{
    [JsonPropertyName("main")]
    public Main Temperatures { get; set; }
}
