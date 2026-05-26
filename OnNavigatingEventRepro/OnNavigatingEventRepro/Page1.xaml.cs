namespace OnNavigatingEventRepro;

public partial class Page1 : ContentPageBase
{
    public Page1()
    {
        InitializeComponent();
    }

    void Page2Button_Clicked(object sender, EventArgs e)
    {
        App.Current.Windows[0].Page = new NavigationPage(new Page2());
    }
}
