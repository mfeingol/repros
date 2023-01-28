namespace ImageButtonClipRepro;

public partial class MainPage : ContentPage
{
    public static readonly BindableProperty IsButtonVisibleProperty = BindableProperty.Create(nameof(IsButtonVisible), typeof(bool), typeof(MainPage), defaultValue: false);

    int count = 0;

	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = this;

		this.Dispatcher.Dispatch(async () =>
		{
            await Task.Delay(1000);
            this.IsButtonVisible = true;
        });
	}

    public bool IsButtonVisible
    {
        get => (bool)GetValue(IsButtonVisibleProperty);
        set => SetValue(IsButtonVisibleProperty, value);
    }

    void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

