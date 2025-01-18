using SQLiteBrowser;
using VictuzMobile.App.Helpers;

namespace VictuzMobile.App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenDbBrowser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseBrowserPage(DatabaseHelpers.GetDatabasePath("mobile-app-casus.db")));
        }
    }

}
