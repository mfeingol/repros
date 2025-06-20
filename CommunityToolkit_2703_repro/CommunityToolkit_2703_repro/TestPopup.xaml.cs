using CommunityToolkit.Maui.Views;

namespace CommunityToolkit_2703_repro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPopup : BooleanPopup
    {
        public TestPopup()
        {
            InitializeComponent();
        }
        
        async void CloseButton_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new();
            using HttpResponseMessage response1 = await client.GetAsync("https://www.microsoft.com");
            using HttpResponseMessage response2 = await client.GetAsync("https://www.google.com");

            GC.Collect();
            await this.CloseAsync(true);
            GC.Collect();
        }
    }

    public class BooleanPopup : Popup<bool>
    {
    }
}