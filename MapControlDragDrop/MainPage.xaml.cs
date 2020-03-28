using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace MapControlDragDrop
{
    public sealed partial class MainPage : Page
    {
        BitmapImage dragPin = new BitmapImage(new Uri("ms-appx:///Assets/Pin.png"));

        public MainPage()
        {
            this.InitializeComponent();
            this.Map.Center = new Geopoint(new BasicGeoposition { Latitude = 36.997, Longitude = -112.009 });
        }

        void Map_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            // Strip altitude
            BasicGeoposition position = new BasicGeoposition { Latitude = args.Location.Position.Latitude, Longitude = args.Location.Position.Longitude };

            Ellipse item = new Ellipse
            {
                Width = 16,
                Height = 16,
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2,
                CanDrag = true,
            };

            item.DragStarting += (s, e) =>
            {
                e.Data.RequestedOperation = DataPackageOperation.Move;
                e.Data.Properties["item"] = item;
                e.AllowedOperations = DataPackageOperation.Move;
            };

            this.Map.Children.Add(item);

            MapControl.SetLocation(item, new Geopoint(position));
            MapControl.SetNormalizedAnchorPoint(item, new Point(0.5, 0.5));

            MapPolyline line = sender.MapElements.OfType<MapPolyline>().FirstOrDefault();
            if (line == null)
            {
                line = new MapPolyline()
                {
                    Path = new Geopath(Enumerable.Repeat(position, 1)),
                    StrokeColor = Colors.Blue,
                    StrokeThickness = 2,
                };

                sender.MapElements.Add(line);
            }
            else
            {
                line.Path = new Geopath(line.Path.Positions.Concat(Enumerable.Repeat(position, 1)));
            }
        }

        void Map_DragOver(object sender, DragEventArgs args)
        {
            if (args.DataView.Properties["item"] is Ellipse ellipse)
            {
                args.AcceptedOperation = DataPackageOperation.Move;
                args.DragUIOverride.IsCaptionVisible = false;
                args.DragUIOverride.IsGlyphVisible = false;
                args.DragUIOverride.SetContentFromBitmapImage(this.dragPin);

                Point point = args.GetPosition(this.Map);
                this.Map.GetLocationFromOffset(point, out Geopoint location);
                BasicGeoposition position = new BasicGeoposition { Latitude = location.Position.Latitude, Longitude = location.Position.Longitude };

                MapControl.SetLocation(ellipse, new Geopoint(position));
                this.UpdatePath();

                args.Handled = true;
            }
        }

        void Map_Drop(object sender, DragEventArgs args)
        {
            if (args.DataView.Properties["item"] is Ellipse ellipse)
            {
                Point point = args.GetPosition(this.Map);
                this.Map.GetLocationFromOffset(point, out Geopoint location);
                BasicGeoposition position = new BasicGeoposition { Latitude = location.Position.Latitude, Longitude = location.Position.Longitude };

                MapControl.SetLocation(ellipse, new Geopoint(position));
                this.UpdatePath();

                args.Handled = true;
            }
        }

        void UpdatePath()
        {
            MapPolyline line = this.Map.MapElements.OfType<MapPolyline>().FirstOrDefault();
            if (line != null)
                line.Path = new Geopath(this.Map.Children.OfType<Ellipse>().Select(e => MapControl.GetLocation(e).Position));
        }
    }
}
