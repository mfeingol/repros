using Android.App;
using Android.Content.PM;

namespace MauiRepro_28051
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }

    partial class LongPressBehavior
    {
        public event EventHandler LongPressed;
        public event EventHandler Clicked;

        public Element View { get; private set; }
    }

    partial class LongPressBehavior : PlatformBehavior<Element, Android.Views.View>
    {
        protected override void OnAttachedTo(Element bindable, Android.Views.View platformView)
        {
            this.View = bindable;
            this.BindingContext = bindable.BindingContext;

            platformView.Click += this.OnClick;
            platformView.LongClick += this.OnLongClick;
        }

        void OnLongClick(object sender, Android.Views.View.LongClickEventArgs args)
        {
            this.LongPressed?.Invoke(this, EventArgs.Empty);
        }

        void OnClick(object sender, EventArgs e)
        {
            this.Clicked?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnDetachedFrom(Element bindable, Android.Views.View platformView)
        {
            this.View = null;
            this.BindingContext = null;

            try
            {
                platformView.Click -= this.OnClick;
                platformView.LongClick -= this.OnLongClick;
            }
            catch (ObjectDisposedException)
            {
                // This is expected if the view is disposed before the behavior
                // and we try to remove the event handler.
            }
        }
    }
}
