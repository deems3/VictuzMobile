using SQLiteBrowser;
using VictuzMobile.App.Helpers;
using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class SettingsView : ContentPage
{
    public SettingsViewModel ViewModel { get; set; }
    public SettingsView()
	{
        ViewModel = new SettingsViewModel();
        BindingContext = ViewModel;

        InitializeComponent();
	}

    private async void OpenDbViewer(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DatabaseBrowserPage(DatabaseHelpers.GetDatabasePath("mobile_app_casus.db")));
    }
}