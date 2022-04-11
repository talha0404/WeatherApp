using System.Collections.ObjectModel;
using System.Globalization;
using WeatherApp.Helper;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp;

public partial class HomePage : ContentPage
{
    WeatherServices weatherServices = new WeatherServices();

    public HomePage()
    {
        InitializeComponent();

        GetLocation();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LocationServices locationServices = new LocationServices();
        cmbCity.ItemsSource = locationServices.SetCityData();

        lblGreetings.Text = "Merhaba " + TOOLS.UserName.ToUpper();

        SetCitiesAroundWorld();
    }

    public async void GetLocation()
    {
        var location = await Geolocation.GetLastKnownLocationAsync();

        if (location != null)
        {
            var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var placemark = placemarks?.FirstOrDefault();   //Diziden ilk boþ olmayaný alýrýz.

            if (placemark is not null)
            {
                Weather weather = weatherServices.GetTemparatureOfCity(placemark.AdminArea);

                lblCityName.Text = placemark.AdminArea;
                lblCityDesc.Text = weather.description;
                lblCityTemp.Text = weather.Temp + " °C";
            }
        }
        else
        {
            Weather weather = weatherServices.GetTemparatureOfCity("Sakarya");

            lblCityName.Text = "Sakarya";
            lblCityDesc.Text = weather.description;
            lblCityTemp.Text = weather.Temp + " °C";

            lblCurrentLocation.IsVisible = false;
        }
    }

    private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Picker picker = (Picker)sender;

            if (picker.SelectedItem == null) return;

            City city = (City)picker.SelectedItem;

            if (!string.IsNullOrWhiteSpace(city.name))
            {
                Weather weather = weatherServices.GetTemparatureOfCity(city.name);

                lblCityName.Text = city.name;
                //imgCityWeather.Source = ImageSource.FromUri(new Uri("http://openweathermap.org/img/wn/" + weather.icon + "@2x.png"));
                lblCityDesc.Text = weather.description;
                lblCityTemp.Text = weather.Temp + " °C";
                lblCurrentLocation.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public void SetCitiesAroundWorld()
    {
        try
        {

            Weather weather = weatherServices.GetTemparatureOfCity("Dubai");

            lblDubai.Text = "Dubai";
            lblDubaiDesc.Text = char.ToUpper(weather.description[0]) + weather.description.Substring(1); ;
            lblDubaiTemp.Text = weather.Temp + " °C";

            Weather weather2 = weatherServices.GetTemparatureOfCity("Delhi");

            lblDelhi.Text = "Delhi";
            lblDelhiDesc.Text = char.ToUpper(weather2.description[0]) + weather2.description.Substring(1);
            lblDelhiTemp.Text = weather2.Temp + " °C";

            Weather weather3 = weatherServices.GetTemparatureOfCity("London");

            lblLondon.Text = "London";
            lblLondonDesc.Text = char.ToUpper(weather3.description[0]) + weather3.description.Substring(1);
            lblLondonTemp.Text = weather3.Temp + " °C";

            Weather weather4 = weatherServices.GetTemparatureOfCity("Tokyo");

            lblTokyo.Text = "Tokyo";
            lblTokyoDesc.Text = char.ToUpper(weather4.description[0]) + weather4.description.Substring(1); ;
            lblTokyoTemp.Text = weather4.Temp + " °C";

            Weather weather5 = weatherServices.GetTemparatureOfCity("Berlin");

            lblBerlin.Text = "Berlin";
            lblBerlinDesc.Text = char.ToUpper(weather5.description[0]) + weather5.description.Substring(1); ;
            lblBerlinTemp.Text = weather5.Temp + " °C";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            throw;
        }
    }
}