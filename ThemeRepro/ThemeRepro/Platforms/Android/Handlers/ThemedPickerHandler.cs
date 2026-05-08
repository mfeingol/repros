using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Android.Content.Res;

namespace ThemeRepro
{
    sealed class ThemedPickerHandler : PickerHandler
    {
        protected override void ConnectHandler(MauiPicker platformView)
        {
            base.ConnectHandler(platformView);
            ThemeSelectorService.EffectiveThemeChanged += this.OnThemeChanged;

            // This only works if done asynchronously
            MainThread.BeginInvokeOnMainThread(() => this.SetColors());
        }

        protected override void DisconnectHandler(MauiPicker platformView)
        {
            ThemeSelectorService.EffectiveThemeChanged -= this.OnThemeChanged;
            base.DisconnectHandler(platformView);
        }

        void OnThemeChanged(object sender, EventArgs e) => this.SetColors();

        void SetColors()
        {
            Color color = ThemeSelectorService.GetThemeColor("PickerUnderlineColor");
            this.PlatformView?.Background.SetTintList(ColorStateList.ValueOf(color.ToAndroid()));
        }
    }
}
