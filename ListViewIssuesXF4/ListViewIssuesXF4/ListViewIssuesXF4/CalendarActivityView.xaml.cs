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
    public partial class CalendarActivityView : Grid
    {
        public CalendarActivityView()
        {
            InitializeComponent();
        }

        void Color_Clicked(object sender, EventArgs e)
        {
            Toast.Toaster.Show("Color_Tapped");
        }

        void Attachments_Tapped(object sender, EventArgs e)
        {
            Toast.Toaster.Show("Attachments_Tapped");
        }

        void Urls_Tapped(object sender, EventArgs e)
        {
            Toast.Toaster.Show("Urls_Tapped");
        }
    }
}