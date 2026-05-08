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
    }
}
