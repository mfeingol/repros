using Microsoft.Maui.Platform;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.PlatformConfiguration.AndroidSpecific;
using AndroidX.Core.View;

namespace CommunityToolkitMauiNavigationBarThemeRepro
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool light = false;

        public MainPage()
        {
            InitializeComponent();
            SetNavigationBarTheme();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            this.light = !this.light;
            SetNavigationBarTheme();
        }

        void SetNavigationBarTheme()
        {
            Color background = this.light ? Colors.White : Colors.Black;

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetColor(background);
            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetStyle(light ? NavigationBarStyle.LightContent : NavigationBarStyle.DarkContent);

#if ANDROID
            Android.Views.Window? window = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity?.Window;
            if (window != null)
            {
#pragma warning disable CA1422
                //window.SetNavigationBarColor(background.ToPlatform());
#pragma warning restore CA1422
                //WindowCompat.GetInsetsController(window, window.DecorView)?.AppearanceLightNavigationBars = light;
            }
#endif
        }
    }
}
