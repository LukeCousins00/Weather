using System.Text.Json.Serialization;

namespace Weather.Models;

public class Coord
{
    [JsonPropertyName("lon")]
    public float Longitude { get; set; }
    [JsonPropertyName("lat")]
    public float Latitude { get; set; }
}