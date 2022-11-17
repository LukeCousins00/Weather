using System.Text.Json.Serialization;

namespace Weather.Models;
public class Main
{
    [JsonPropertyName("temp")]
    public float Temperature { get; set; }

    [JsonPropertyName("feels_like")]
    public float Feels { get; set; }

    [JsonPropertyName("temp_min")]
    public float minimumTemperature { get; set; }

    [JsonPropertyName("temp_max")]
    public float maximumTemperature { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}
