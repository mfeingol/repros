using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms_7642_ListView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public MainPageViewModel ViewModel { get; } = new MainPageViewModel();

        void Header_Tapped(object sender, EventArgs e)
        {
        }
    }

    public class MainPageViewModel
    {
        public ObservableCollection<GroupViewModel> Groups { get; set; } = new ObservableCollection<GroupViewModel>
        {
            new GroupViewModel { GroupTitle = "Group1" },
            new GroupViewModel { GroupTitle = "Group2" },
            new GroupViewModel { GroupTitle = "Group3" },
        };
    }

    public class GroupViewModel : ObservableCollection<ItemViewModel>
    {
        public GroupViewModel()
        {
            this.Add(new ItemViewModel { ItemTitle = "Item1" });
            this.Add(new ItemViewModel { ItemTitle = "Item2" });
            this.Add(new ItemViewModel { ItemTitle = "Item3" });
        }
        public string GroupTitle { get; set; }
    }

    public class ItemViewModel
    {
        public string ItemTitle { get; set; }
    }
}
