namespace RefreshViewInTabbedPageRepro
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.CV1.ItemsSource = Enumerable.Range(1, 100).Select(i => i.ToString()).ToList();
            this.CV2.ItemsSource = Enumerable.Range(1, 100).Select(i => i.ToString()).ToList();
        }
    }

}
