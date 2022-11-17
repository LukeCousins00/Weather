using Microsoft.AspNetCore.Mvc;
using Weather.Services;
using Weatherv2.Models;
using Weatherv2.ViewModels;

namespace Weather.Controllers;

public class HomeController : Controller
{
    private readonly IWeatherService _weatherService;

    public HomeController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new HomeViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(string location)
    {
        var longLat = await _weatherService.GetLongLatAsync(location);

        if (longLat == null)
        {
            HomeViewModel viewModel = new HomeViewModel
            {
                Location = location,
                Error = true,
            };

            return View(viewModel);
        }

        WeatherApiCall weatherData = await _weatherService.GetWeatherDataAsync(longLat[0], longLat[1]);

        HomeViewModel viewmodel = new HomeViewModel
        {
            Weather = weatherData,
            Location = location
        };

        return View(viewmodel);
    }
}
