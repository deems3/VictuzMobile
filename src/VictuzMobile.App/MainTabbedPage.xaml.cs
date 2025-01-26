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
    )
    {
        InitializeComponent();
        _mainPageView = mainPageView;
        _activitiesView = activitiesView;
        _profileView = profileView;
        _settingsView = settingsView;

        Children.Add(new NavigationPage(_mainPageView) { Title = "Home", IconImageSource = "home.svg" });
        Children.Add(new NavigationPage(_activitiesView) { Title = "Activities", IconImageSource = "activities.svg" });
        Children.Add(new NavigationPage(_profileView) { Title = "Profile", IconImageSource = "profile.svg" });
        Children.Add(new NavigationPage(_settingsView) { Title = "Settings", IconImageSource = "settings.svg" });
    }
}