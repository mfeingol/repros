using System.Collections.ObjectModel;

namespace ListViewIssuesXF4
{
    public class DayViewModel : Observable, IExpandable
    {
        bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set { Set(ref this.isExpanded, value); }
        }

        string title;
        public string Title
        {
            get { return this.title; }
            set { Set(ref this.title, value); }
        }

        string summary;
        public string Summary
        {
            get { return this.summary; }
            set { Set(ref this.summary, value); }
        }

        ObservableCollection<ActivityViewModel> activities;
        public ObservableCollection<ActivityViewModel> Activities
        {
            get { return this.activities; }
            set { Set(ref this.activities, value); }
        }
    }
}
