namespace ThemeRepro
{
    public sealed class NavigationService
    {
        public static NavigationService Instance { get; } = new();

        public ShellPage ShellPage => App.Current.Windows.FirstOrDefault()?.Page as ShellPage;
        public NavigationPage NavigationPage => this.ShellPage?.Detail as NavigationPage;

        public void NavigateToMainPage<T>(object parameter = null) where T : Page, new()
        {
            // Don't navigate to same page
            Type prevPageType = this.NavigationPage?.RootPage.GetType();
            if (prevPageType == typeof(T))
                return;

            this.NavigateToMainPage(new T(), parameter);
        }

        async void NavigateToMainPage(Page page, object parameter = null)
        {
            NavigationPage navigation = new(page);
            this.ShellPage.Detail = navigation;
        }
    }
}
