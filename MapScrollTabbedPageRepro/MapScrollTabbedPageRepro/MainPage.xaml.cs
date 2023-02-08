namespace MapScrollTabbedPageRepro;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await App.Current.MainPage.Navigation.PushAsync(new TabbedPageRepro());
	}
}

