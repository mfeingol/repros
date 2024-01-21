using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListViewItemsDisappearingRepro
{
    public partial class MainPage : ContentPage
    {
        const int TotalItems = 15;

        readonly Timer timer;
        readonly Random random = new();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            this.RefreshQueue();

            this.timer = new Timer(OnTimerTick, null, 12, 12);
        }

        public PageViewModel ViewModel { get; } = new();

        void RefreshQueue()
        {
            this.ViewModel.QueuedDownloads.Clear();

            for (int i = 1; i < TotalItems + 1; i++)
            {
                this.ViewModel.QueuedDownloads.Add(new DownloadItemViewModel
                {
                    Name = $"Download {i}",
                    Description = $"Description {i}",
                    Progress = 0,
                });
            }
            this.UpdateStatus();
        }

        void UpdateStatus()
        {
            this.ViewModel.Status = $"Status: {this.ViewModel.QueuedDownloads.Count} downloads";
        }

        void OnTimerTick(object state)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                int selected = this.random.Next(TotalItems + 1);
                if (selected < this.ViewModel.QueuedDownloads.Count)
                {
                    DownloadItemViewModel item = this.ViewModel.QueuedDownloads[selected];
                    item.Progress++;
                    if (item.Progress == 100)
                    {
                        this.ViewModel.QueuedDownloads.RemoveAt(selected);
                        this.UpdateStatus();
                    }
                }
            });
        }

        void Restart_Clicked(object sender, EventArgs e)
        {
            this.RefreshQueue();
        }

        //
        // No-ops
        //

        void CancelDownload_Clicked(object sender, EventArgs e)
        {
        }
    }

    //
    // View Models
    //

    public class PageViewModel : Observable
    {
        ObservableCollection<DownloadItemViewModel> queuedDownloads = [];
        public ObservableCollection<DownloadItemViewModel> QueuedDownloads
        {
            get => this.queuedDownloads;
            set => Set(ref this.queuedDownloads, value);
        }

        string status;
        public string Status
        {
            get => this.status;
            set => Set(ref this.status, value);
        }
    }

    public class DownloadItemViewModel : Observable
    {
        string name;
        public string Name
        {
            get => this.name;
            set => Set(ref this.name, value);
        }

        string description;
        public string Description
        {
            get => this.description;
            set => Set(ref this.description, value);
        }

        int progress;
        public int Progress
        {
            get => this.progress;
            set
            {
                if (Set(ref this.progress, value))
                    this.OnPropertyChanged(nameof(this.ProgressFraction));
            }
        }

        public double ProgressFraction => ((double)this.Progress) / 100;
    }

    public abstract class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected bool Set<T>(T storage, T value, Action<T> assign, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            assign(value);

            this.OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
