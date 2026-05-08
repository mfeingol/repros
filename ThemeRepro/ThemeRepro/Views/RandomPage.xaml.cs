namespace ThemeRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class RandomPage : ContentPage
    {
        public RandomPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}
