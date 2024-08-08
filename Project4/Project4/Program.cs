using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter city name: ");
            string cityName = Console.ReadLine();

            var cityData = GetCityData(cityName);

            if (cityData.HasValue)
            {
                double latitude = cityData.Value.Item1;
                double longitude = cityData.Value.Item2;

                string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";
                var weatherData = await FetchWeatherData(apiUrl);

                if (weatherData != null)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(weatherData, Formatting.Indented));
                }
                else
                {
                    Console.WriteLine("Weather data not found.");
                }
            }
            else
            {
                Console.WriteLine("City not found in CSV.");
            }
        }

        static (double, double)? GetCityData(string cityName)
        {
            var lines = File.ReadAllLines(@"C:\Users\IBZ\Desktop\Ankit Practice\Project4\Project4\Data\in.csv");
        var cityLine = lines.Skip(1)
                                .Select(line => line.Split(','))
                                .FirstOrDefault(parts => parts[0].Equals(cityName, StringComparison.OrdinalIgnoreCase));

            if (cityLine != null)
            {
                double latitude = double.Parse(cityLine[1]);
                double longitude = double.Parse(cityLine[2]);
                return (latitude, longitude);
            }

            return null;
        }

        static async Task<dynamic> FetchWeatherData(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject(jsonData);
                }

                return null;
            }
        }
    }
}
