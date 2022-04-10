using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helper;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherServices
    {
        public Weather GetTemparatureOfCity(string CityName)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                string a = client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={CityName}&appid=" + TOOLS.WeatherApiKey + "&units=metric").Result;

                var jo = JObject.Parse(a);
                var id = jo["main"].ToString();

                var weather = JsonConvert.DeserializeObject<Weather>(id);

                return weather;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}
