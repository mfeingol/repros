using Android.Views;
using Microsoft.Maui.Platform;

namespace CollectionViewLongPressBehaviorRepro
{
    public partial class LongPressBehavior : PlatformBehavior<Microsoft.Maui.Controls.View, Android.Views.View>
    {
        Microsoft.Maui.Controls.View bindable;

        protected override void OnAttachedTo(Microsoft.Maui.Controls.View bindable, Android.Views.View platformView)
        {
            base.OnAttachedTo(bindable, platformView);

            if (bindable != null && platformView != null)
            {
                this.bindable = bindable;
                platformView.LongClick += this.OnPlatformViewLongClick;

                foreach (MenuItem menuItem in this.ContextActions)
                    menuItem.BindingContext = bindable.BindingContext;
            }
        }

        protected override void OnDetachedFrom(Microsoft.Maui.Controls.View bindable, Android.Views.View platformView)
        {
            base.OnDetachedFrom(bindable, platformView);

            if (platformView != null)
                platformView.LongClick -= this.OnPlatformViewLongClick;
        }

        void OnPlatformViewLongClick(object sender, Android.Views.View.LongClickEventArgs args)
        {
            if (!this.ContextActions.Any(i => i.IsEnabled))
                return;

            Microsoft.Maui.Controls.View backgroundHolder = this.bindable; // element.LongPressBackgroundColorElement ?? element;
            Brush originalBackground = backgroundHolder.Background;

            void onCreate() => backgroundHolder.Background =
                Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M ? MainActivity.Activity.Resources.GetColor(Resource.Color.material_deep_teal_500, MainActivity.Activity.Theme).ToColor() :
#pragma warning disable 0618
                                                                                    MainActivity.Activity.Resources.GetColor(Resource.Color.material_deep_teal_500).ToColor();
#pragma warning restore 0618
            void onDestroy() => backgroundHolder.Background = originalBackground;

            ActionModeCallback cb = new(this.ContextActions, onCreate, onDestroy);
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                MainActivity.Activity.StartActionMode(cb, Android.Views.ActionModeType.Primary);
            else
                MainActivity.Activity.StartActionMode(cb);
        }

        sealed class ActionModeCallback : Java.Lang.Object, Android.Views.ActionMode.ICallback
        {
            readonly MenuItem[] contextActions;
            readonly Action onCreate;
            readonly Action onDestroy;

            public ActionModeCallback(IEnumerable<MenuItem> contextActions, Action onCreate = null, Action onDestroy = null)
            {
                this.contextActions = contextActions.ToArray();
                this.onCreate = onCreate;
                this.onDestroy = onDestroy;
            }

            public bool OnCreateActionMode(Android.Views.ActionMode mode, Android.Views.IMenu menu)
            {
                for (int i = 0; i < this.contextActions.Length; i++)
                    menu.Add(0, i, 0, this.contextActions[i].Text);

                this.onCreate?.Invoke();
                return true;
            }

            public void OnDestroyActionMode(Android.Views.ActionMode mode)
            {
                this.onDestroy?.Invoke();
            }

            public bool OnActionItemClicked(Android.Views.ActionMode mode, Android.Views.IMenuItem item)
            {
                ((IMenuItemController)this.contextActions[item.ItemId]).Activate();

                mode.Finish();
                return true;
            }

            public bool OnPrepareActionMode(Android.Views.ActionMode mode, Android.Views.IMenu menu)
            {
                return false;
            }
        }
    }
}
