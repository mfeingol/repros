namespace ListViewIssuesXF4.Droid
{
    public class DroidToast : IToast
    {
        public void Show(string message, ToastLength length = ToastLength.Short)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, (Android.Widget.ToastLength)length).Show();
        }
    }
}
