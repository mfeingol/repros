[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ThemeRepro
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            ThemeSelectorService.SetSelectedTheme(AppTheme.Dark);
            return new Window(new ShellPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            NavigationService.Instance.NavigateToMainPage<SettingsPage>();
        }

        public object GetResource(string key)
        {
            foreach (ResourceDictionary dict in this.Resources.MergedDictionaries)
            {
                if (dict.TryGetValue(key, out object val))
                    return val;
            }
            throw new ArgumentException("Resource not found", key);
        }
    }
}
