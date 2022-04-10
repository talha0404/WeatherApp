using System.Collections.ObjectModel;
using System.Globalization;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp;

public partial class HomePage : ContentPage
{
    public List<Weather> Weathers =new List<Weather>();
    public HomePage()
    {
        InitializeComponent();

        BindingContext = this;
        LocationServices locationServices = new LocationServices();
        List<Country> a = locationServices.GetAllCountries().Result;

        cmbCountry.ItemsSource = a;
        //cmbCity.ItemsSource = a;
        //cmbDistrict.ItemsSource = a;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        WeatherServices weatherServices = new WeatherServices();
        weatherServices.GetTemparatureOfCity("sakarya");

        Weathers.Add(new Weather() { Temp = "20°", Feels_like = "Sýcak" });
        Weathers.Add(new Weather() { Temp = "50°", Feels_like = "Soðuk" });
        Weathers.Add(new Weather() { Temp = "30°", Feels_like = "Sýcak" });

        //crsWeather.ItemsSource = Weathers;
    }

    private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}