using WeatherApp.Helper;

namespace WeatherApp;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private void btnEntry_Clicked(object sender, EventArgs e)
    {
        try
        {
            TOOLS.UserName = txtUsername.Text;
            Navigation.PushModalAsync(new HomePage());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            throw;
        }
    }
}