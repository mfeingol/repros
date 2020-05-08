using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Notifications;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotificationsRepro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        void Toast_Click(object sender, RoutedEventArgs e)
        {
            ToastContent content = new ToastContent
            {
                HintToastId = "16cb717c-0352-49b2-a9bc-e0d674b8b2f9",
                Launch = String.Empty,

                Header = new ToastHeader("16cb717c-0352-49b2-a9bc-e0d674b8b2f9", "Repro Toast", String.Empty),

                Visual = new ToastVisual
                {
                    BindingGeneric = new ToastBindingGeneric
                    {
                        Children =
                        {
                            new AdaptiveText { Text = "Repro Toast Title", HintStyle = AdaptiveTextStyle.Title },
                            new AdaptiveText { Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                        }
                    }
                },
                Actions = new ToastActionsCustom
                {
                    Buttons =
                    {
                        new ToastButton("Hello World", String.Empty) { ActivationType = ToastActivationType.Foreground },
                    }
                },
            };

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
    }
}
