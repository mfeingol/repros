namespace CheckboxBindingRepro;

public partial class MainPage : ContentPage
{
    public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(MainPage), defaultValue: false);
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IList<MainPage>), typeof(MainPage));

    public MainPage()
	{
		InitializeComponent();
        this.BindingContext = this;

        this.Items = new[] { this };
    }

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public IList<MainPage> Items
    {
        get => (IList<MainPage>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
}
