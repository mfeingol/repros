using System;
using Xamarin.Forms;

namespace ListViewIssuesXF4
{
    public class ToggleButton : Button
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(ToggleButton), false, propertyChanged: IsSelectedPropertyChanged);
        public static readonly BindableProperty AutoToggleProperty = BindableProperty.Create(nameof(AutoToggle), typeof(bool), typeof(ToggleButton), false);
        public static readonly BindableProperty TagProperty = BindableProperty.Create(nameof(Tag), typeof(object), typeof(ToggleButton));

        Color defaultColor;

        public ToggleButton()
        {
            this.defaultColor = this.BackgroundColor;
            this.Clicked += this.OnClicked;
        }

        void OnClicked(object sender, EventArgs e)
        {
            if (this.AutoToggle)
                this.IsSelected = !this.IsSelected;
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public bool AutoToggle
        {
            get { return (bool)GetValue(AutoToggleProperty); }
            set { SetValue(AutoToggleProperty, value); }
        }

        public object Tag
        {
            get { return (object)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        static void IsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton button = (ToggleButton)bindable;
            button.BackgroundColor = button.IsSelected ? (Color)Application.Current.Resources["PrimaryLightest"] : button.defaultColor;
        }
    }
}
