using System;
using System.Text.Json;
using System.Windows.Input;
using MauiWeather.MVVM.Models;

namespace Clima.MVVM.ViewModels
{
	public class WeatherViewModel
	{
        public WeatherData WeatherData { get; set; }
        private HttpClient client;

        // Constructor
        public WeatherViewModel()
        {
            client = new HttpClient();
        }

        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                var location = await GetCoordinatesAsync(searchText.ToString());
                Console.WriteLine("location: " + location);
                await GetWeather(location);
            });

        private async Task GetWeather(Location location)
        {
            var url =
                    $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    WeatherData = data;
                    Console.WriteLine("temp: " + data.current_weather.temperature);
                }
            }
        }

        // Recibe una cadena
        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding
                 .Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if (location != null)
                Console
                     .WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            return location;
        }
    }
}

