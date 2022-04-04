namespace WeatherApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current asdsa: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

