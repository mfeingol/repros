using System.Diagnostics;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace WorkingWithMaps.Views;

public partial class GrowingPolylinePage : ContentPage
{
	public GrowingPolylinePage()
	{
		InitializeComponent();

		MainThread.BeginInvokeOnMainThread(async () => await RenderAsync());
	}

    async Task RenderAsync()
    {
		Location NW = new(48.60660019765632, -121.6898628046794);
        Location SW = new(34.932324583554866, -115.69598307100047);

        this.Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location((NW.Latitude + SW.Latitude) / 2, (NW.Longitude + SW.Longitude) / 2), Distance.FromMiles(400.0)));

        Polyline polyline = [];
        polyline.StrokeColor = Colors.Red;

        this.Map.Pins.Add(new Pin { Location = NW, Label = "Start" });
        this.Map.Pins.Add(new Pin { Location = SW, Label = "Finish" });

        this.Map.MapElements.Add(polyline);

        Random rand = new((int)DateTime.Now.Ticks);

        const int steps = 500;

        for (int step = 0; step < steps; step ++)
		{
            double longitudeJitter = rand.NextDouble() / 5;
            polyline.Add(new Location(NW.Latitude - ((NW.Latitude - SW.Latitude) * step) / steps, NW.Longitude - ((NW.Longitude - SW.Longitude) * step) / steps + longitudeJitter));

            await Task.Delay(20);

            Debug.WriteLine($"Step {step} of {steps}");
        }
    }
}
