using System.Diagnostics;

namespace OnNavigatingEventRepro;

public abstract class ContentPageBase : ContentPage
{
    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        Debug.WriteLine($"OnNavigatingFrom: {this.Title} [{args.NavigationType}], DestinationPage={args.DestinationPage?.Title}");
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        Debug.WriteLine($"OnNavigatedFrom: {this.Title} [{args.NavigationType}], DestinationPage={args.DestinationPage?.Title}");
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Debug.WriteLine($"OnNavigatedTo: {this.Title} [{args.NavigationType}], PreviousPage={args.PreviousPage?.Title}");
    }
}
