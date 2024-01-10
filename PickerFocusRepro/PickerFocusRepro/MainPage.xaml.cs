namespace PickerFocusRepro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public IList<string> ThreeItems { get; } = ["One", "Two", "Three"];
        public IList<string> OneItem { get; } = ["One"];
    }
}
