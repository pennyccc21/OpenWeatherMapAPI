using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Xml.Linq;

namespace OpenWeatherMapAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var client = new HttpClient();
            //Console.WriteLine("Please enter your API key:");
            var apiKey = "cadbda51caaa480b209e262059156c8f";


            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Please enter the city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to enter a different city?");
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "no" || userInput.ToLower() == "n")
                {
                    break;
                }

            }
        }
    }
}
