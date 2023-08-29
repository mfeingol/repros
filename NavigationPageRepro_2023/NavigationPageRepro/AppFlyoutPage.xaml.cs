namespace NavigationPageRepro;

public partial class AppFlyoutPage : FlyoutPage
{
	public AppFlyoutPage()
	{
		InitializeComponent();
		this.appFlyoutPageMenu.FlyoutPage = this;
    }

	public void NavigateTo(Type type)
	{
        this.Detail = new NavigationPage((Page)Activator.CreateInstance(type));
        if (!((IFlyoutPageController)this).ShouldShowSplitMode)
            this.IsPresented = false;
    }
}
