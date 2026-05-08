namespace ThemeRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            this.Picker.ItemsSource = new List<string> { "OSRM", "Google Maps", "Bing Maps" };
        }

        async void AlertButton_Clicked(object sender, EventArgs e)
        {
            await this.DisplayAlertAsync("Title", "Message", "Cancel");
        }
    }
}
