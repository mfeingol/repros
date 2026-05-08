namespace ThemeRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class ShellPageFlyout : ContentPage
    {
        public ShellPageFlyout()
        {
            this.InitializeComponent();
            this.BindingContext = this;
        }

        public event EventHandler MenuItemSelected;

        void Help_Clicked(object sender, EventArgs e) => this.NavigateToPage<HelpPage>();
        void Settings_Clicked(object sender, EventArgs e) => this.NavigateToPage<SettingsPage>();
        void Random_Clicked(object sender, EventArgs e) => this.NavigateToPage<RandomPage>();

        void NavigateToPage<T>() where T : Page, new()
        {
            this.MenuItemSelected?.Invoke(this, EventArgs.Empty);
            NavigationService.Instance.NavigateToMainPage<T>();
        }
    }
}
