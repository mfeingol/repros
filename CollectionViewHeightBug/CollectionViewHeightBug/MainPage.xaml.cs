using System.Collections.ObjectModel;

namespace CollectionViewHeightBug
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<object> Items { get; set; } = new()
        {
            new(),
            new(),
            new(),
            new(),
        };

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}
