using Android.App;
using Android.Content.PM;

namespace ThemeRepro;

[Activity(Theme = "@style/CustomTheme", MainLauncher = true, Exported = true, LaunchMode = LaunchMode.SingleTask, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public sealed class MainActivity : MauiAppCompatActivity
{
}
