namespace ThemeRepro
{
    static class ThemeSelectorService
    {
        public static event EventHandler EffectiveThemeChanged;

        public static void SetSelectedTheme(AppTheme theme)
        {
            AppTheme prevEffective = EffectiveTheme;

            SetMauiAppTheme(theme);

            AppTheme newEffective = EffectiveTheme;
            if (newEffective != prevEffective)
            {
                EffectiveThemeChanged?.Invoke(new object(), EventArgs.Empty);
                SetSystemAppTheme(theme);
            }
        }

        public static AppTheme EffectiveTheme
        {
            get
            {
                if (Application.Current.UserAppTheme != AppTheme.Unspecified)
                    return Application.Current.UserAppTheme;

                return Application.Current.RequestedTheme switch
                {
                    AppTheme.Dark => AppTheme.Dark,
                    AppTheme.Light => AppTheme.Light,
                    _ => AppTheme.Light
                };
            }
        }

        static void SetMauiAppTheme(AppTheme theme)
        {
            App.Current.UserAppTheme = theme;
        }

        static void SetSystemAppTheme(AppTheme theme)
        {
            SystemUI.SetAppTheme(theme);
        }

        public static Color GetThemeColor(string resource)
        {
            string key = EffectiveTheme == AppTheme.Light ? $"Light_{resource}" : $"Dark_{resource}";
            return (Color)((App)App.Current).GetResource(key);
        }
    }
}
