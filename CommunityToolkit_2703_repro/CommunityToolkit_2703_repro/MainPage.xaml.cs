using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace CommunityToolkit_2703_repro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnCounterClicked(object sender, EventArgs e)
        {
            TestPopup popup = new();

            IPopupResult<bool> popupResult = await this.ShowPopupAsync<bool>(popup, new PopupOptions()
            {
                Shape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(4),
                    Stroke = Colors.Blue,
                    StrokeThickness = 4
                },
                Shadow = new Shadow
                {
                    Brush = Brush.Green,
                    Opacity = 0.8f
                }
            });

            if (popupResult.WasDismissedByTappingOutsideOfPopup)
                await DisplayAlert("Result", "Popup result is null", "OK");
            else
                await DisplayAlert("Result", $"Popup closed with {popupResult.Result} result", "OK");
        }
    }
}
