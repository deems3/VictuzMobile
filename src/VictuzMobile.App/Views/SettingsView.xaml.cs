using SQLiteBrowser;
using VictuzMobile.App.Helpers;

namespace VictuzMobile.App.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView()
	{
		InitializeComponent();
	}

    private async void OpenDbViewer(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DatabaseBrowserPage(DatabaseHelpers.GetDatabasePath("mobile_app_casus.db")));
    }
}