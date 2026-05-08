using Platform = Microsoft.Maui.ApplicationModel.Platform;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;

namespace ThemeRepro
{
    static class SystemUI
    {
        public static void SetAppTheme(AppTheme theme)
        {
            SetNightMode(theme);
            SetStatusBarColor(ThemeSelectorService.GetThemeColor("StatusBarColor"));
            SetNavigationBarColor(Colors.Black);
        }

        static void SetNightMode(AppTheme theme)
        {
            AppCompatDelegate.DefaultNightMode = theme switch
            {
                AppTheme.Dark => AppCompatDelegate.ModeNightYes,
                AppTheme.Light => AppCompatDelegate.ModeNightNo,
                _ => AppCompatDelegate.ModeNightFollowSystem,
            };
        }

        static void SetStatusBarColor(Color statusBarColor)
        {
            Android.App.Activity activity = Platform.CurrentActivity;
            Android.Views.Window window = activity?.Window;
            if (window != null)
            {
                const string StatusBarOverlayTag = "StatusBarOverlay";

                // Compute real inset top (status bar + OEM inset)
                // If the insets aren't ready yet (early layout), correct it later via the inset listener
                WindowInsetsCompat compatInsets = ViewCompat.GetRootWindowInsets(window.DecorView);
                int insetTop = compatInsets != null ? compatInsets.GetInsets(WindowInsetsCompat.Type.SystemBars()).Top : 0;

                ViewGroup decorGroup = (ViewGroup)window.DecorView;
                Android.Views.View statusBarOverlay = (decorGroup).FindViewWithTag(StatusBarOverlayTag);
                if (statusBarOverlay == null)
                {
                    statusBarOverlay = new(activity)
                    {
                        LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, insetTop)
                        {
                            Gravity = GravityFlags.Top
                        },
                        Tag = StatusBarOverlayTag
                    };
                    decorGroup.AddView(statusBarOverlay);
                    statusBarOverlay.SetZ(0);
                }
                else
                {
                    FrameLayout.LayoutParams lp = (FrameLayout.LayoutParams)statusBarOverlay.LayoutParameters;
                    lp.Height = insetTop;
                    statusBarOverlay.LayoutParameters = lp;
                }

                statusBarOverlay.SetBackgroundColor(statusBarColor.ToAndroid());

                // Light/dark icon appearance
                WindowCompat.GetInsetsController(window, decorGroup).AppearanceLightStatusBars = false;

                // Attach inset listener
                window.DecorView.SetOnApplyWindowInsetsListener(new InsetsListener(statusBarOverlay));
            }
        }

        static void SetNavigationBarColor(Color color)
        {
#pragma warning disable CA1422
            Platform.CurrentActivity?.Window.SetNavigationBarColor(color.ToPlatform());
#pragma warning restore CA1422
        }

        class InsetsListener(Android.Views.View overlay) : Java.Lang.Object, Android.Views.View.IOnApplyWindowInsetsListener
        {
            public WindowInsets OnApplyWindowInsets(Android.Views.View v, WindowInsets insets)
            {
                // Convert the insets provided by the system
                // Fallback: some devices provide incomplete insets on first dispatch
                WindowInsetsCompat compat = WindowInsetsCompat.ToWindowInsetsCompat(insets) ?? ViewCompat.GetRootWindowInsets(v);
                int newTop = compat?.GetInsets(WindowInsetsCompat.Type.SystemBars()).Top ?? 0;

                FrameLayout.LayoutParams lp = (FrameLayout.LayoutParams)overlay.LayoutParameters;
                if (lp.Height != newTop)
                {
                    lp.Height = newTop;
                    overlay.LayoutParameters = lp;
                }
                return insets;
            }
        }
    }
}
