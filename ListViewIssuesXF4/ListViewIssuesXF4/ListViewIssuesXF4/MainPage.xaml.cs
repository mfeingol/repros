using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewIssuesXF4
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public CalendarPageViewModel ViewModel { get; } = new CalendarPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        void Activity_Tapped(object sender, ItemTappedEventArgs e)
        {
            Toast.Toaster.Show("Activity_Tapped");
        }
    }
}
