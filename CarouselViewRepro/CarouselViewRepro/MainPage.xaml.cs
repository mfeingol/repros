using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarouselViewRepro;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel { get; } = new();

    public MainPage()
	{
		InitializeComponent();
        this.BindingContext = this;
	}
	
    void Button_Clicked(object sender, EventArgs e)
    {
        int index = this.ViewModel.Items.IndexOf(this.ViewModel.SelectedItem);
        index = (++index) % this.ViewModel.Items.Count;

        this.ViewModel.SelectedItem = this.ViewModel.Items[index];
    }
}

public class MainPageViewModel : Observable
{
    public List<string> Items { get; } = new() { "1", "2", "3", "4", "5" };

    string selectedItem = "1";
    public string SelectedItem
    {
        get => this.selectedItem;
        set => this.Set(ref this.selectedItem, value);
    }
}

public abstract class Observable : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(storage, value))
            return false;

        storage = value;
        this.OnPropertyChanged(propertyName);
        return true;
    }
    
    public void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
