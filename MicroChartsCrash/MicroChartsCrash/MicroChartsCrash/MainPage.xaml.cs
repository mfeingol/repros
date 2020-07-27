using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;

namespace MicroChartsCrash
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            List<ChartEntry> entries = new List<ChartEntry>();

            for (int i = 0; i < 100; i++)
            {
                entries.Add(new ChartEntry(i + 100) { Color = SKColors.Black });

                if (i % 20 == 0)
                    entries[i].ValueLabel = $"Label {i}";
            }

            this.Chart = new LineChart
            {
                LabelColor = SKColors.LavenderBlush,
                BackgroundColor = SKColors.Red,
                Entries = entries,
                LineMode = LineMode.Straight,
                PointMode = PointMode.Circle,
                LabelTextSize = 28,
            };

            InitializeComponent();
            this.BindingContext = this;
        }

        public LineChart Chart { get; }
    }
}
