namespace ListViewIssuesXF4
{
    public enum ToastLength
    {
        Short = 0,
        Long = 1
    }

    public interface IToast
    {
        void Show(string message, ToastLength length = ToastLength.Short);
    }

    public static class Toast
    {
        public static IToast Toaster { get; set; }
    }
}
