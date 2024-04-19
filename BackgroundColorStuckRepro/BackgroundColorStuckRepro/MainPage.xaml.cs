using AndroidX.AppCompat.View;
using CommunityToolkit.Maui.Behaviors;

namespace BackgroundColorCrashRepro
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        void OnCounterClicked(object sender, EventArgs e)
        {
        }

        void LongPressBehavior_LongPressed(object sender, EventArgs e)
        {
            LongPressBehavior behavior = (LongPressBehavior)sender;
            VisualElement view = (VisualElement)behavior.View;

            Brush originalBackground = view.Background;
            Color originalBackgroundColor = view.BackgroundColor;

            void onCreate()
            {
                Color longPressedHighlightColor = Colors.Green;

                view.Background = null;
                view.BackgroundColor = longPressedHighlightColor;
            }

            void onDestroy()
            {
                view.Background = originalBackground;
                view.BackgroundColor = originalBackgroundColor;
            }

#if ANDROID
            ContextAction[] actions =
                [
                new()
                {
                    Text = "Copy",
                    OnClicked = () => {}
                },
                new()
                {
                    Text = "Paste",
                    OnClicked = () => {}
                }
                ];

            ActionModeCallback cb = new(actions, onCreate, onDestroy);
            ((MainActivity)Platform.CurrentActivity).StartSupportActionMode(cb);
#endif
        }
    }

    class LongPressBehavior : TouchBehavior
    {
        public LongPressBehavior()
        {
            this.LongPressCommand = new Command(() => this.LongPressed?.Invoke(this, EventArgs.Empty));
        }

        public event EventHandler LongPressed;

        public new Element View => base.View;
    }

#if ANDROID
    sealed class ContextAction
    {
        public string Text { get; set; }
        public bool IsDestructive { get; set; }
        public Action OnClicked { get; set; }
    }

    class ActionModeCallback : Java.Lang.Object, ActionMode.ICallback
    {
        readonly IEnumerable<ContextAction> actions;
        readonly Action onCreate;
        readonly Action onDestroy;

        readonly Dictionary<int, ContextAction> items = new();

        public ActionModeCallback(IEnumerable<ContextAction> actions, Action onCreate = null, Action onDestroy = null)
        {
            this.actions = actions;
            this.onCreate = onCreate;
            this.onDestroy = onDestroy;
        }

        public bool OnActionItemClicked(ActionMode mode, Android.Views.IMenuItem item)
        {
            if (this.items.TryGetValue(item.Order, out ContextAction m))
                m.OnClicked?.Invoke();

            // Close action mode
            mode.Finish();
            return true;
        }

        public bool OnCreateActionMode(ActionMode mode, Android.Views.IMenu menu)
        {
            int index = 0;
            foreach (ContextAction item in this.actions)
            {
                menu.Add(0, index, index, new Java.Lang.String(item.Text));
                this.items[index] = item;
                index++;
            }

            this.onCreate?.Invoke();
            return true;
        }

        public void OnDestroyActionMode(ActionMode mode)
        {
            this.onDestroy?.Invoke();
        }

        public bool OnPrepareActionMode(ActionMode mode, Android.Views.IMenu menu)
        {
            return false;
        }
    }
#endif
}

