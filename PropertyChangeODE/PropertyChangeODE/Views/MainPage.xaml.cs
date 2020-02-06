using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PropertyChangeODE.Models;

namespace PropertyChangeODE.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
        }

        public async Task NavigateFromMenu(int id)
        {
            NavigationPage newPage = null;

            switch (id)
            {
                case (int)MenuItemType.Browse:
                    newPage = new NavigationPage(new ItemsPage());
                    break;
                case (int)MenuItemType.About:
                    newPage = new NavigationPage(new AboutPage());
                    break;
            }

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}