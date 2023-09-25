namespace CollectionViewLongPressBehaviorRepro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.CV1.ItemsSource = new List<string>
            {
                "Item1",
                "Item2",
                "Item3",
                "Item4",
                "Item5",
            };

            this.CV2.ItemsSource = new List<string>
            {
                "Item6",
                "Item7",
                "Item8",
                "Item9",
                "Item10",
            };
        }

        private void CV_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            string selected = (string)args.CurrentSelection.First();
            DisplayAlert("Selected", selected, "OK");
        }
    }
}
