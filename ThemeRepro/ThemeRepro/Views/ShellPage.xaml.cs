namespace ThemeRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class ShellPage : FlyoutPage
    {
        public ShellPage()
        {
            this.InitializeComponent();
            this.ShellPageFlyout.MenuItemSelected += this.OnMenuItemSelected;
        }

        void OnMenuItemSelected(object sender, EventArgs e) => this.IsPresented = false;
    }
}
