namespace OnNavigatingEventRepro;

public partial class Page21 : ContentPageBase
{
	public Page21()
	{
		InitializeComponent();
	}

    private void Page211Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new Page211());
    }
}
