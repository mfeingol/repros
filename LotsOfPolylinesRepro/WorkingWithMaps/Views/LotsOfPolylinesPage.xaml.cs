using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace WorkingWithMaps.Views;

public partial class LotsOfPolylinesPage : ContentPage
{
    public LotsOfPolylinesPage()
    {
        InitializeComponent();

        MainThread.BeginInvokeOnMainThread(() => Render());
    }

    void Render()
    {
        Location NW = new(48.60660019765632, -121.6898628046794);
        Location SW = new(34.932324583554866, -115.69598307100047);

        this.Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location((NW.Latitude + SW.Latitude) / 2, (NW.Longitude + SW.Longitude) / 2), Distance.FromMiles(600.0)));

        // Change the count and steps to obtain different results. I see it falling over about here, but your mileage might vary
        const int count = 92;
        const int steps = 500;

        Random rand = new((int)DateTime.Now.Ticks);

        for (int i = 0; i < count; i++)
        {
            NW.Longitude += 0.8;
            SW.Longitude += 0.8;

            Polyline polyline = [];
            polyline.StrokeColor = Colors.Red;

            for (int step = 0; step < steps; step++)
            {
                double longitudeJitter = rand.NextDouble() / 2;
                polyline.Add(new Location(NW.Latitude - (NW.Latitude - SW.Latitude) * step / steps, NW.Longitude - (NW.Longitude - SW.Longitude) * step / steps + longitudeJitter));
            }

            this.Map.MapElements.Add(polyline);
        }
    }
}
