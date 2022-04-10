using Android.Content;
using Android.Content.Res;
using Android.OS;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Platforms.Android.Renderer;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]

namespace WeatherApp.Platforms.Android.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        private Context context;
        public CustomPickerRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.NewElement == null) return;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(global::Android.Graphics.Color.Transparent);
            else
                Control.Background.SetColorFilter(global::Android.Graphics.Color.Transparent, global::Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
}
