namespace NavigationPageRepro;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppFlyoutPage { Detail = new NavigationPage(new MainPage1()) };
	}
}
