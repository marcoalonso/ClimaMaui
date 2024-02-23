﻿using System;
using System.Windows.Input;

namespace Clima.MVVM.ViewModels
{
	public class WeatherViewModel
	{
        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                var location = await GetCoordinatesAsync(searchText.ToString());
                Console.WriteLine("location: " + location);
            });

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

