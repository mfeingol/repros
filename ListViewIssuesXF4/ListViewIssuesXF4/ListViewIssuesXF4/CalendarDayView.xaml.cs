using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewIssuesXF4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayView : StackLayout
    {
        DayGroupViewModel dayModel;
        DayViewModel day;

        public CalendarDayView()
        {
            InitializeComponent();
            this.BindingContextChanged += this.OnBindingContextChanged;
        }

        void OnBindingContextChanged(object sender, EventArgs args)
        {
            this.BindingContextChanged -= this.OnBindingContextChanged;

            this.dayModel = (DayGroupViewModel)this.BindingContext;
            this.day = this.dayModel?.Day;
        }

        void Title_Tapped(object sender, EventArgs e)
        {
            if (!ContextMenuService.IsDisplayingContextMenu)
            {
                this.day.IsExpanded = !this.day.IsExpanded;
            }
        }
    }
}
