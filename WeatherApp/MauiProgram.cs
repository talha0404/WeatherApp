using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using WeatherApp.Platforms.Android.Renderer;

namespace WeatherApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            #if ANDROID
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddCompatibilityRenderer(typeof(Picker), typeof(CustomPickerRenderer));
                //handlers.AddCompatibilityRenderer(typeof(Entry), typeof(CustomEntryRenderer));
            })
            #endif
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        return builder.Build();
    }
}
