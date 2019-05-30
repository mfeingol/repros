using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewIssuesXF4
{
    public class ActivityViewModel : Observable
    {
        string color;
        public string Color
        {
            get { return this.color; }
            set { Set(ref this.color, value); }
        }

        bool isAutomatic;
        public bool IsAutomatic
        {
            get { return this.isAutomatic; }
            set { Set(ref this.isAutomatic, value); }
        }

        string summary;
        public string Summary
        {
            get { return this.summary; }
            set { Set(ref this.summary, value); }
        }
    }
}
