namespace OnNavigatingEventRepro;

public partial class Page2 : ContentPageBase
{
	public Page2()
	{
		InitializeComponent();
	}

    void Page1Button_Clicked(object sender, EventArgs e)
    {
		App.Current.Windows[0].Page = new NavigationPage(new Page1());
    }

    private void Page21Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new Page21());
    }
}
