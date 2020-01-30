using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(Map), typeof(TileExceptionHang.Droid.CustomMapRenderer))]
namespace TileExceptionHang.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        TileOverlay overlay;
        bool online = true;

        public CustomMapRenderer(Context context) : base(context)
        {
            ((MainPage)App.Current.MainPage).ButtonClicked += this.MainPage_ButtonClicked;
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            this.EnableTileOverlay();
        }

        void MainPage_ButtonClicked(object sender, EventArgs e)
        {
            this.online = !this.online;
            this.EnableTileOverlay();
        }

        public void EnableTileOverlay()
        {
            GoogleMap map = this.NativeMap;
            if (map != null)
            {
                if (this.overlay != null)
                    this.overlay.Remove();

                TileOverlayOptions options = new TileOverlayOptions();
                options.InvokeTileProvider(this.online ? (ITileProvider)new OnlineTileProvider() : new OfflineTileProvider());

                map.MapType = GoogleMap.MapTypeNone;

                this.overlay = map.AddTileOverlay(options);
            }
        }

        public void DisableTileOverlay()
        {
            if (this.overlay != null)
            {
                this.overlay.Remove();
                this.overlay = null;
            }
        }
    }

    class OnlineTileProvider : UrlTileProvider
    {
        public OnlineTileProvider() : base(256, 256)
        {
        }

        public override Java.Net.URL GetTileUrl(int x, int y, int z)
        {
            string url = $"https://a.tile.openstreetmap.org/{z}/{x}/{y}.png"; 
            return new Java.Net.URL(url);
        }
    }

    class OfflineTileProvider : Java.Lang.Object, ITileProvider
    {
        public OfflineTileProvider()
        {
        }

        public Tile GetTile(int x, int y, int zoom)
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Tiles",
                zoom.ToString(CultureInfo.InvariantCulture),
                x.ToString(CultureInfo.InvariantCulture),
                Path.ChangeExtension(y.ToString(CultureInfo.InvariantCulture), ".png"));

            try
            {
                // Synchronous since the tile interface is synchronous
                byte[] bytes = File.ReadAllBytes(path);
                return new Tile(256, 256, bytes);
            }
            catch (DirectoryNotFoundException e)
            {
                Debug.WriteLine($"DirectoryNotFoundException: {e.Message}");
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine($"FileNotFoundException: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }

            return TileProvider.NoTile;
        }
    }
}
