namespace NavigationPageRepro;

public partial class AppFlyoutPageMenu : ContentPage
{
	public AppFlyoutPageMenu()
	{
		InitializeComponent();
	}

    public AppFlyoutPage FlyoutPage { get; set; }

    void MainPage1Button_Clicked(object sender, EventArgs e)
    {
        this.FlyoutPage.NavigateTo(typeof(MainPage1));
    }

    void MainPage2Button_Clicked(object sender, EventArgs e)
    {
        this.FlyoutPage.NavigateTo(typeof(MainPage2));
    }
}
