namespace NavigationPageRepro
{
    public partial class MainPage2 : ContentPage
    {
        public MainPage2()
        {
            InitializeComponent();
        }

        async void NavigateButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new DetailsPage2());
        }
    }
}
