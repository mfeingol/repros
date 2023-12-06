namespace NavigationPageRepro;

public partial class AppFlyoutPage : FlyoutPage
{
	public AppFlyoutPage()
	{
		InitializeComponent();
		this.Menu.FlyoutPage = this;
    }

	public void NavigateTo(Type type)
	{
        NavigationPage nav = new((Page)Activator.CreateInstance(type));

        // This doesn't work, and it's a regression from Xamarin Forms
        //this.Detail = nav;

        // This is the workaround I've found
        App.Current.MainPage = new AppFlyoutPage { Detail = nav };

        if (!((IFlyoutPageController)this).ShouldShowSplitMode)
            this.IsPresented = false;
    }
}
