using System.Collections.Generic;
using Xamarin.Forms;

namespace PropertyChangeODE.Views
{
    class ConditionalToolbarItem : ToolbarItem
    {
        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(ConditionalToolbarItem), defaultValue: true, propertyChanged: IsVisiblePropertyChanged);
        public static readonly BindableProperty IndexProperty = BindableProperty.Create(nameof(Index), typeof(int), typeof(ConditionalToolbarItem), defaultValue: 0);

        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        static void IsVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ConditionalToolbarItem item = (ConditionalToolbarItem)bindable;

            Device.BeginInvokeOnMainThread(() =>
            {
                IList<ToolbarItem> items = ((Page)item.Parent)?.ToolbarItems;
                if (items != null)
                {
                    bool setValue = item.IsVisible;

                    if (setValue && !items.Contains(item))
                    {
                        int index = items.Count;
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (((ConditionalToolbarItem)items[i]).Index > item.Index)
                            {
                                index = i;
                                break;
                            }
                        }
                        items.Insert(index, item);
                    }
                    else if (!setValue && items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
            });
        }
    }
}
