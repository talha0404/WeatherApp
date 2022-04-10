using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using WeatherApp.Models;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Services
{
    public class LocationServices
    {
        static string CountryUrl = "https://restcountries.com/v3.1/all";
        static HttpClient client = new HttpClient();

        public async Task<List<Country>> GetAllCountries()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                string a = client.GetStringAsync("https://api.first.org/data/v1/countries").Result;

                var jo = JObject.Parse(a);
                var id = jo["data"].ToString();

                var dict = JsonConvert.DeserializeObject<Dictionary<string, Country>>(id);

                List<Country> countryList = new List<Country>();

                foreach (KeyValuePair<string, Country> kvp in dict)
                {
                    Country c = new Country();
                    c.CountryCode = kvp.Key;
                    c.country = kvp.Value.country;
                    c.region = kvp.Value.region;                   
                    
                    countryList.Add(c);
                }

                return countryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }

    }
}
