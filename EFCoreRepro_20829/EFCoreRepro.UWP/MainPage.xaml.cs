using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.EntityFrameworkCore;
using EFCoreRepro.Schema;

namespace EFCoreRepro.UWP
{
    public sealed partial class MainPage : Page
    {
        Structure? structure = new Structure { StringValue = "S1" };

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs args)
        {
            base.OnNavigatedTo(args);

            using (DatabaseContext db = new DatabaseContext())
            {
                var q1 = await (from e in db.Entities
                                where e.StringValue1 == this.structure.Value.StringValue
                                select e).ToListAsync();

                string stringValue = this.structure.Value.StringValue;

                var q2 = await (from e in db.Entities
                                where e.StringValue1 == stringValue
                                select e).ToListAsync();

                await new ContentDialog
                {
                    Title = $"{q1.Count} should equal {q2.Count}",
                    Content = q1.Count == q2.Count ? "Succcess" : "Failure",
                    CloseButtonText = "OK"
                }.ShowAsync();
            }
        }
    }

    struct Structure
    {
        public string StringValue { get; set; }
    }
}
