﻿using Android.App;
using Android.Content.PM;

namespace CollectionViewLongPressBehaviorRepro
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static MainActivity Activity { get; private set; }

        public MainActivity()
        {
            Activity = this;
        }
    }
}
