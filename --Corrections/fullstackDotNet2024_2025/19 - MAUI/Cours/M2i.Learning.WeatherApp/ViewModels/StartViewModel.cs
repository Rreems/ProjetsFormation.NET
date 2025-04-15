using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using M2i.Learning.WeatherApp.Models;
using PropertyChanged;

namespace M2i.Learning.WeatherApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class StartViewModel
    {
        public WeatherAPIResponse WeatherInfos { get; set; }
        public string PlaceSearched { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsVisible { get; set; }
        public bool IsLoading { get; set; }

        public ICommand SearchCommand => new Command(async (obj) =>
        {
            var searchText = (string)obj;
            PlaceSearched = searchText;
            if (string.IsNullOrEmpty(searchText)) return;
            var location = await GetCoordinatesAsync(searchText);
            await GetWeatherInfos(location);
        });


        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding
                 .Default.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            return location;
        }

        private async Task GetWeatherInfos(Location location)
        {
            var _httpClient = new HttpClient();

            var lat = location.Latitude;
            var lng = location.Longitude;

            IsLoading = true;
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lng}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using var contentAsStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<WeatherAPIResponse>(contentAsStream);

                if (data != null)
                {
                    WeatherInfos = data;

                    for (int i = 0; i < WeatherInfos.daily.weathercode.Length; i++)
                    {
                        var daily2 = new Daily2()
                        {
                            time = WeatherInfos.daily.time[i],
                            weathercode = WeatherInfos.daily.weathercode[i],
                            temperature_2m_max = WeatherInfos.daily.temperature_2m_max[i],
                            temperature_2m_min = WeatherInfos.daily.temperature_2m_min[i],
                        };

                        WeatherInfos.daily2.Add(daily2);
                    }

                    IsVisible = true;
                }
            }

            IsLoading = false;

        }
    }
}
