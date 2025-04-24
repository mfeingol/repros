using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiRepro_28051
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            this.SetFolders();
        }

        public ViewModel ViewModel { get; } = new();

        void ReproToolbarItem_Clicked(object sender, EventArgs e)
        {
            this.SetFolders();
        }

        void SetFolders()
        {
            this.ViewModel.Current = new()
            {
                Folders =
                [
                    new() { Name = Guid.NewGuid().ToString(), IsExpanded = true, Items =
                    [
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = false, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                    ] },
                    new() { Name = Guid.NewGuid().ToString(), IsExpanded = false, Items =
                    [
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = false, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                    ] },
                    new() { Name = Guid.NewGuid().ToString(), IsExpanded = true, Items =
                    [
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = false, Summary = Guid.NewGuid().ToString() },
                        new() { HasColorButton = true, Summary = Guid.NewGuid().ToString() },
                    ] },
                ]
            };

            var folders = this.ViewModel.Current.Folders;
            this.ViewModel.Current.Folders = null;
            this.ViewModel.Current.Folders = folders;
        }

        void Folder_Clicked(object sender, EventArgs e)
        {
            LongPressBehavior behavior = (LongPressBehavior)sender;
            FolderViewModel folder = (FolderViewModel)behavior.BindingContext;
            folder.IsExpanded = !folder.IsExpanded;
        }

        void Folder_LongPressed(object sender, EventArgs e)
        {

        }

        void Item_Clicked(object sender, EventArgs e)
        {

        }

        void Item_LongPressed(object sender, EventArgs e)
        {

        }
    }

    public class ViewModel : Observable
    {
        BucketViewModel current;
        public BucketViewModel Current
        {
            get => this.current;
            set => this.Set(ref this.current, value);
        }
    }

    public class BucketViewModel : Observable
    {
        ObservableCollection<FolderViewModel> folders;
        public ObservableCollection<FolderViewModel> Folders
        {
            get => this.folders;
            set => this.Set(ref this.folders, value);
        }
    }

    public class FolderViewModel : Observable
    {
        string name;
        public string Name
        {
            get => this.name;
            set => this.Set(ref this.name, value);
        }

        bool isExpanded;
        public bool IsExpanded
        {
            get => this.isExpanded;
            set => this.Set(ref this.isExpanded, value);
        }

        ObservableCollection<ItemViewModel> items;
        public ObservableCollection<ItemViewModel> Items
        {
            get => this.items;
            set => this.Set(ref this.items, value);
        }
    }

    public class ItemViewModel : Observable
    {
        bool hasColorButton;
        public bool HasColorButton
        {
            get => this.hasColorButton;
            set => this.Set(ref this.hasColorButton, value);
        }

        string summary;
        public string Summary
        {
            get => this.summary;
            set => this.Set(ref this.summary, value);
        }
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

        void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
