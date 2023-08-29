namespace NavigationPageRepro
{
    public partial class MainPage1 : ContentPage
    {
        public MainPage1()
        {
            InitializeComponent();
        }

        async void NavigateButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new DetailsPage1());
        }
    }
}
