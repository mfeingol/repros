using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace ListViewIssuesXF4
{
    public class CalendarPageViewModel : Observable
    {
        public CalendarPageViewModel()
        {
            List<DayViewModel> days = new List<DayViewModel>
            {
                new DayViewModel
                {
                    Title = "July 5",
                    Summary = "A beautiful day in Hanksville",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Duke's Slickrock Grill",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Duke's Slickrock Grill",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 6",
                    Summary = "A beautiful day in Capitol Reef",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",

                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 7",
                    Summary = "A beautiful day in the Grand Staircase",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Egypt III",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Egypt III",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Broken Bow Arch Trailhead",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Broken Bow Arch",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 8",
                    Summary = "A beautiful day in Hanksville",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Duke's Slickrock Grill",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Duke's Slickrock Grill",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 9",
                    Summary = "A beautiful day in Capitol Reef",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",

                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 10",
                    Summary = "A beautiful day in the Grand Staircase",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Egypt III",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Egypt III",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Broken Bow Arch Trailhead",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Broken Bow Arch",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 11",
                    Summary = "A beautiful day in Hanksville",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Factory Butte",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Duke's Slickrock Grill",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Duke's Slickrock Grill",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 12",
                    Summary = "A beautiful day in Capitol Reef",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Cohab Canyon",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",

                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                },
                new DayViewModel
                {
                    Title = "July 13",
                    Summary = "A beautiful day in the Grand Staircase",
                    IsExpanded = true,
                    Activities = new ObservableCollection<ActivityViewModel>
                    {
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Egypt III",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Egypt III",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Broken Bow Arch Trailhead",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF00FF00",
                            IsAutomatic = false,
                            Summary = "Hike Broken Bow Arch",
                        },
                        new ActivityViewModel
                        {
                            IsAutomatic = true,
                            Summary = "Drive to Cowboy Blues",
                        },
                        new ActivityViewModel
                        {
                            Color = "#FF0000FF",
                            IsAutomatic = false,
                            Summary = "Dine at Cowboy Blues",
                        },
                    }
                }
            };

            this.DayGroups = new DayGroupCollectionViewModel(days);
        }

        DayGroupCollectionViewModel dayGroups;
        public DayGroupCollectionViewModel DayGroups
        {
            get { return this.dayGroups; }
            set { Set(ref this.dayGroups, value); }
        }
    }

    public class DayGroupCollectionViewModel : ExpandableGroupCollectionViewModel<DayGroupViewModel, DayViewModel, ActivityViewModel>
    {
        static ObservableCollection<ActivityViewModel> empty = new ObservableCollection<ActivityViewModel>();

        public DayGroupCollectionViewModel(IReadOnlyList<DayViewModel> expandables)
        {
            this.Initialize(expandables);
        }

        protected override (DayGroupViewModel, DayGroupViewModel) CreateGroups(DayViewModel day)
        {
            return (new DayGroupViewModel(day, () => day.Activities), new DayGroupViewModel(day, () => empty));
        }
    }

    public class DayGroupViewModel : ExpandableGroupViewModel<DayViewModel, ActivityViewModel>
    {
        public DayGroupViewModel(DayViewModel day, Func<ObservableCollection<ActivityViewModel>> getActivities) : base(day, getActivities)
        {
            this.Day = day;
        }

        public DayViewModel Day { get; }
    }

    public abstract class ExpandableGroupCollectionViewModel<TExpandableGroup, TGroup, TItem> : Observable where TGroup : IExpandable
                                                                                                           where TExpandableGroup : ExpandableGroupViewModel<TGroup, TItem>
    {
        protected void Initialize(IReadOnlyList<TGroup> expandables)
        {
            this.Groups = new ObservableCollection<TExpandableGroup>();
            this.ShadowGroups = new ObservableCollection<TExpandableGroup>();

            for (int i = 0; i < expandables.Count; i++)
            {
                TGroup expandable = expandables[i];

                (var group, var shadowGroup) = this.CreateGroups(expandable);

                if (expandable.IsExpanded)
                {
                    this.Groups.Add(group);
                    this.ShadowGroups.Add(shadowGroup);
                }
                else
                {
                    this.Groups.Add(shadowGroup);
                    this.ShadowGroups.Add(group);
                }

                expandable.PropertyChanged += this.OnExpandablePropertyChanged;
            }
        }

        protected abstract (TExpandableGroup, TExpandableGroup) CreateGroups(TGroup expandable);

        ObservableCollection<TExpandableGroup> groups;
        public ObservableCollection<TExpandableGroup> Groups
        {
            get { return this.groups; }
            set { Set(ref this.groups, value); }
        }

        ObservableCollection<TExpandableGroup> shadowGroups;
        public ObservableCollection<TExpandableGroup> ShadowGroups
        {
            get { return this.shadowGroups; }
            set { Set(ref this.shadowGroups, value); }
        }

        void OnExpandablePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IExpandable.IsExpanded))
            {
                TGroup expandable = (TGroup)sender;

                int index = this.GetIndex(expandable);
                Debug.Assert(index != -1);

                var temp = this.Groups[index];
                this.Groups[index] = this.ShadowGroups[index];
                this.ShadowGroups[index] = temp;
            }
        }

        int GetIndex(TGroup expandable)
        {
            for (int i = 0; i < this.Groups.Count; i++)
            {
                if (ReferenceEquals(this.Groups[i].Inner, expandable) || ReferenceEquals(this.ShadowGroups[i].Inner, expandable))
                    return i;
            }
            return -1;
        }
    }

    public abstract class ExpandableGroupViewModel<TGroup, TItem> : ObservableCollection<TItem> where TGroup : IExpandable
    {
        Func<IReadOnlyList<TItem>> getSource;
        IReadOnlyList<TItem> source;

        protected ExpandableGroupViewModel(TGroup expandable, Func<IReadOnlyList<TItem>> getSource)
        {
            this.getSource = getSource;
            this.Inner = expandable;

            this.Refresh();
        }

        public TGroup Inner { get; private set; }

        bool isEmpty;
        public bool IsEmpty
        {
            get { return this.isEmpty; }
            set
            {
                if (!Equals(this.isEmpty, value))
                {
                    this.isEmpty = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsEmpty)));
                }
            }
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Refresh();
        }

        public void Refresh()
        {
            this.Clear();

            IReadOnlyList<TItem> source = getSource();
            if (!ReferenceEquals(this.source, source))
            {
                if (this.source != null && this.source is INotifyCollectionChanged oldChanged)
                    oldChanged.CollectionChanged -= this.OnCollectionChanged;

                this.source = source;

                if (this.source is INotifyCollectionChanged newChanged)
                    newChanged.CollectionChanged += this.OnCollectionChanged;
            }

            foreach (TItem item in this.source)
                this.Add(item);

            this.IsEmpty = !this.Any();
        }
    }

    public interface IExpandable : INotifyPropertyChanged
    {
        bool IsExpanded { get; set; }
    }
}
