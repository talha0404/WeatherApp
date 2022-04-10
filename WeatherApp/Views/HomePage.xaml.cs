using System.Collections.ObjectModel;
using System.Globalization;
using WeatherApp.Helper;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp;

public partial class HomePage : ContentPage
{
    public List<Weather> Weathers = new List<Weather>();
    public List<City> Cities = new List<City>();
    public HomePage()
    {
        InitializeComponent();

        BindingContext = this;
        LocationServices locationServices = new LocationServices();
        Cities = locationServices.SetCityData();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        cmbCity.ItemsSource = Cities;
    }

    private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {

        Picker picker = (Picker)sender;

        if (picker.SelectedItem == null) return;

        City city = (City)picker.SelectedItem;

        string cityName = city.name;

        if (!string.IsNullOrWhiteSpace(cityName))
        {
            WeatherServices weatherServices = new WeatherServices();
            Weather weather = weatherServices.GetTemparatureOfCity(cityName);
        }
    }
}