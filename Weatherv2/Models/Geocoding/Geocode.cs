using System.Text.Json.Serialization;
using Weatherv2.Models;

namespace Weather.Models;
public class Geocode
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("lat")]
    public float Latitude { get; set; }

    [JsonPropertyName("lon")]
    public float Longitude { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("local_names")]
    public LocalNames LocalNames { get; set; }
}