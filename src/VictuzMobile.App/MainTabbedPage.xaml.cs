using VictuzMobile.App.Views;

namespace VictuzMobile;

public partial class MainTabbedPage : TabbedPage
{
    private readonly MainPageView _mainPageView;
    private readonly ActivitiesView _activitiesView;
    private readonly ProfileView _profileView;
    private readonly SettingsView _settingsView;

    public MainTabbedPage(
        MainPageView mainPageView,
        ActivitiesView activitiesView,
        ProfileView profileView,
        SettingsView settingsView
    ) {
        InitializeComponent();
        _mainPageView = mainPageView;
        _activitiesView = activitiesView;
        _profileView = profileView;
        _settingsView = settingsView;

        Children.Add(new NavigationPage(_mainPageView) { Title = "Home", IconImageSource = "home.svg" });
        Children.Add(new NavigationPage(_activitiesView) { Title = "Activities", IconImageSource = "activities.svg" });
        Children.Add(new NavigationPage(_profileView) { Title = "Profile", IconImageSource = "profile.svg" });
        Children.Add(new NavigationPage(_settingsView) { Title = "Settings", IconImageSource = "settings.svg" });

        UpdateBarBackgroundColor();
        Application.Current.RequestedThemeChanged += OnRequestedThemeChanged;
    }


    private void OnRequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        UpdateBarBackgroundColor();
    }

    private void UpdateBarBackgroundColor() // Background of the tabbar wouldn't update on theme switch, so now this method forces it to update
    {
        if (Application.Current.RequestedTheme == AppTheme.Dark)
        {
            BarBackgroundColor = (Color)Application.Current.Resources["OffBlack"];
            UnselectedTabColor = (Color)Application.Current.Resources["IconUnselectedDark"];
            SelectedTabColor = (Color)Application.Current.Resources["IconSelectedDark"];
        }
        else
        {
            BarBackgroundColor = (Color)Application.Current.Resources["VictuzLight"];
            UnselectedTabColor = (Color)Application.Current.Resources["IconUnselected"];
            SelectedTabColor = (Color)Application.Current.Resources["IconSelected"];
        }
    }
}