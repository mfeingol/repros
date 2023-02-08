using Microsoft.Maui.Maps.Handlers;

namespace MapVisibleRegionRepro;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        this.Map.MapClicked += Map_MapClicked;
	}

    void Map_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
		Location location = this.Map.VisibleRegion.Center;
		this.Label.Text = $"{location.Latitude}, {location.Longitude}";
    }
}

class CustomMap : Microsoft.Maui.Controls.Maps.Map
{
}

class CustomMapHandler : MapHandler
{
    protected override void ConnectHandler(Android.Gms.Maps.MapView platformView)
    {
        base.ConnectHandler(platformView);
        platformView.GetMapAsync(new CustomMapCallbackHandler(this));
    }

    internal void OnMapReady(Android.Gms.Maps.GoogleMap googleMap)
    {
        googleMap.CameraMove += this.OnCameraMoved;
        // or
        //googleMap.SetOnCameraMoveListener(new CustomMapOnCameraMoveListener(this));
    }

    void OnCameraMoved(object sender, EventArgs e)
    {
    }

    internal void OnCameraMove()
    {
    }
}

class CustomMapCallbackHandler : Java.Lang.Object, Android.Gms.Maps.IOnMapReadyCallback
{
    readonly CustomMapHandler handler;

    public CustomMapCallbackHandler(CustomMapHandler handler)
    {
        this.handler = handler;
    }

    public void OnMapReady(Android.Gms.Maps.GoogleMap map)
    {
        this.handler.OnMapReady(map);
    }
}

class CustomMapOnCameraMoveListener : Java.Lang.Object, Android.Gms.Maps.GoogleMap.IOnCameraMoveListener
{
    readonly CustomMapHandler handler;

    public CustomMapOnCameraMoveListener(CustomMapHandler handler)
    {
        this.handler = handler;
    }

    public void OnCameraMove()
    {
        this.handler.OnCameraMove();
    }
}
