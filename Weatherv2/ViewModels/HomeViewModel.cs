using System.Text.Json.Serialization;
using Weather.Models;
using Weatherv2.Models;

namespace Weatherv2.ViewModels;

public class HomeViewModel
{
    public WeatherApiCall Weather { get; set; }
    public string Location { get; set; }
    public bool Error { get; set; }
}
