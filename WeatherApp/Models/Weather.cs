using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Weather
    {
        public string Temp { get; set; }
        public string Feels_like { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
    }
}
