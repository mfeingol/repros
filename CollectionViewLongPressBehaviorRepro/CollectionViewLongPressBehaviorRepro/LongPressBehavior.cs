using System.Collections.ObjectModel;

namespace CollectionViewLongPressBehaviorRepro
{
    public partial class LongPressBehavior
    {
        public static readonly BindableProperty ContextActionsProperty = BindableProperty.Create(nameof(ContextActions), typeof(IList<MenuItem>), typeof(LongPressBehavior),
            defaultValueCreator: b => new ObservableCollection<MenuItem>());

        public IList<MenuItem> ContextActions
        {
            get => (IList<MenuItem>)GetValue(ContextActionsProperty);
            set => SetValue(ContextActionsProperty, value);
        }
    }
}
