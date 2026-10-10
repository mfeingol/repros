using static Android.Content.Res.Resources;

namespace ThemeRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            SystemUI.SetAppTheme(AppTheme.Dark);
        }
    }
}
