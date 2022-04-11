using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Weather
    {
        public string CityName { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string Temp { get; set; }
        public string Feels_like { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
    }
}
